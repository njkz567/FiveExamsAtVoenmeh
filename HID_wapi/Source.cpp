#include <stdio.h>
#include <stdlib.h>
#include "hidapi.h"
#include <stdint.h>
#include <locale.h>
#include <string.h>
#include <wchar.h>

// для логов
#include <fstream>

#define DLL _declspec(dllexport)

extern "C" {

	struct PinSlider 
	{
		bool button1;
		bool button2;
		bool button3;
		bool button4;
		unsigned int slider;
	};

	hid_device* handleLeft = NULL;
	hid_device* handleRight = NULL;
	unsigned char buf[256];

	// открытие плат
	DLL bool OpenHID() 
	{
		printf("hidapi test/example tool. Compiled with hidapi version %s, runtime version %s.\n", HID_API_VERSION_STR, hid_version_str());
		if (hid_version()->major == HID_API_VERSION_MAJOR && hid_version()->minor == HID_API_VERSION_MINOR && hid_version()->patch == HID_API_VERSION_PATCH) {
			printf("Compile-time version matches runtime version of hidapi.\n\n");
		}
		else {
			printf("Compile-time version is different than runtime version of hidapi.\n]n");
		}

		if (hid_init())
			return false;

		// Open the device using the VID, PID,
		// and optionally the Serial number.
		////handle = hid_open(0x4d8, 0x3f, L"12345");

		handleLeft = hid_open(0x1234, 0x0001, NULL);
		if (!handleLeft) 
			return false;
		std::fstream out;
		out.open("lold3.txt");
		handleRight = hid_open(0x1235, 0x0001, NULL);
		if (!handleRight) {
			
			out << "e";
			
			return false;
		}
		out << "y";
		out.close();

		return true;
	}

	DLL void ClearScreen() 
	{
		memset(buf, 0x0, sizeof(buf));
		// запись номера команды
		buf[0] = 0x6;
		hid_send_feature_report(handleLeft, buf, sizeof(buf));
	}

	// отправка данных на плату
	DLL int Send(uint8_t* data)
	{
		unsigned int len = 63;

		std::ofstream out;
		out.open("log2.txt");
		for (int j = 0; j < 1024; j++)
		{
			for (int i = 0; i < 8; i++)
				if (*(data + j) & (1 << i))
					out << "1";
				else
					out << "0";
			out << "\n";
		}
		out.close();

		// отправялем 16 * 63 = 1008 байт
		for (uint16_t i = 0; i < 16; i++)
		{
			memset(buf, 0x0, sizeof(buf));
			// запись номера команды
			buf[0] = 0x5;
			// записываем 63 байта в один пакет
			for (uint16_t j = 1; j < len + 1; j++)
				buf[j] = *(data + len * i + j - 1);
			
			if (hid_send_feature_report(handleLeft, buf, sizeof(buf)) == -1)
				return -1;
		}
		len = 16;
		// добрасываем оставшиеся 16 байт
		memset(buf, 0x0, sizeof(buf));
		// запись номера команды
		buf[0] = 0x5;
		// записываем 16 байт в один пакет
		for (uint16_t j = 1; j < len + 1; j++)
			buf[j] = *(data + 1008 + j - 1);

		if (hid_send_feature_report(handleLeft, buf, sizeof(buf)) == -1)
			return -1;

		return 0;
	}

	DLL int LightPixel(uint8_t x, uint8_t y, uint8_t color)
	{
		memset(buf, 0x0, sizeof(buf));
		// запись команды
		buf[0] = 0x4;
		buf[1] = x;
		buf[2] = y;
		buf[3] = color;
		return hid_send_feature_report(handleLeft, buf, sizeof(buf));
	}

	DLL int LED_ON()
	{
		memset(buf, 0x0, sizeof(buf));
		buf[0] = 0x2;
		buf[1] = 0xff;
		buf[2] = 0xff; // 2 byte = uint16_t = power of light color 1
		buf[3] = 0x00; //
		buf[4] = 0x00; // 2 byte = uint16_t = power of light color 2
		buf[5] = 0xff; //
		buf[6] = 0xff; // 2 byte = uint16_t = power of light color 3

		return hid_send_feature_report(handleLeft, buf, sizeof(buf));
	}

	DLL int LED_OFF()
	{
		memset(buf, 0x0, sizeof(buf));
		buf[0] = 0x2;
		buf[1] = 0x00;
		buf[2] = 0x00; // 2 byte = uint16_t = power of light color 1
		buf[3] = 0x00; //
		buf[4] = 0x00; // 2 byte = uint16_t = power of light color 2
		buf[5] = 0x00; //
		buf[6] = 0x00; // 2 byte = uint16_t = power of light color 3

		return hid_send_feature_report(handleLeft, buf, sizeof(buf));
	}

	// считывает значения кнопок и реостата
	DLL uint8_t Read(PinSlider* left, PinSlider* right)
	{
		// левая плата
		memset(buf, 0x0, sizeof(buf));
		buf[0] = 0x01;
		if (hid_get_feature_report(handleLeft, buf, sizeof(buf)) == -1)
			return 1;
		left->button1 = buf[1] & 0x01;
		left->button2 = buf[1] & 0x02;
		left->button3 = buf[1] & 0x04;
		left->button4 = buf[1] & 0x08;
		memcpy(&left->slider, &buf[2], 2);

		//// правая плата
		//memset(buf, 0x0, sizeof(buf));
		//buf[0] = 0x01;
		//if (hid_get_feature_report(handleRight, buf, sizeof(buf)) == -1)
		//{
		//	return 2;
		//}
		//right->button1 = buf[1] & 0x01;
		//right->button2 = buf[1] & 0x02;
		//right->button3 = buf[1] & 0x04;
		//right->button4 = buf[1] & 0x08;
		//memcpy(&right->slider, &buf[2], 2);
		return 0;
	}
}