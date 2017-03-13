#include "Arduino.h"

#include <SoftwareSerial.h>
#include <SerialCommand.h>

#define pinD4 4
#define pinD6 6
#define pinD8 8

#define INIT_PIN 4
#define DOOR_PIN 6
#define RESET_PIN 8

void pinTest();
void softReset();
void pingHandler();
void initHandler();
void closeHandler();
void openHandler();
void quet_auto_closeHandler();

SerialCommand sCmd;

unsigned long startTime = 0;
unsigned long interval = 10000;
bool inited = false;
bool door_open = false;

void setup()
{
    //pinTest();

    pinMode(INIT_PIN, OUTPUT);
    pinMode(DOOR_PIN, OUTPUT);

    digitalWrite(RESET_PIN, HIGH);
    pinMode(RESET_PIN, OUTPUT);

    Serial.begin(9600);
  	while (!Serial);

  	sCmd.addCommand("PING", pingHandler);
    sCmd.addCommand("INIT", initHandler);
    sCmd.addCommand("CLOSE", closeHandler);
    sCmd.addCommand("OPEN", openHandler);
}

void loop()
{
    if (Serial.available() > 0)
		  sCmd.readSerial();

    unsigned long currentTime = millis();

    if (currentTime - startTime > interval && inited && door_open)
    {
      quet_auto_closeHandler();
    }
}

void pinTest()
{
  pinMode(pinD4, OUTPUT);
  digitalWrite(pinD4, HIGH);

  pinMode(pinD6, OUTPUT);
  digitalWrite(pinD6, HIGH);

  pinMode(pinD8, OUTPUT);
  digitalWrite(pinD8, HIGH);
}

void softReset()
{
  digitalWrite(RESET_PIN, LOW);
}

void pingHandler()
{
  	Serial.println("PONG");
}

void initHandler()
{
    if (inited == true)
    {
      Serial.println("ALREADY INITED");
      return;
    }

    digitalWrite(INIT_PIN, HIGH);
    inited = true;
    Serial.println("INITED");
}

void closeHandler()
{
    if (inited == false)
    {
      Serial.println("ALREADY CLOSED");
      return;
    }

    digitalWrite(INIT_PIN, LOW);
    inited = false;
    Serial.println("CLOSED");
    softReset();
}

void openHandler()
{
    if (inited == false)
    {
      Serial.println("NOT INITED");
      return;
    }

    door_open = true;
    digitalWrite(DOOR_PIN, HIGH);
    Serial.println("DOOR OPEN");

    startTime = millis();
}

void quet_auto_closeHandler()
{
    digitalWrite(DOOR_PIN, LOW);
    door_open = false;
    //Serial.println("DOOR CLOSED");
}
