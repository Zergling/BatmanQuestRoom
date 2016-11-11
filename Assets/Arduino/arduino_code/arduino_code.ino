#include <SoftwareSerial.h>
#include <SerialCommand.h>
SerialCommand sCmd;

void setup() 
{
  Serial.begin(9600);
  while (!Serial);

  //sCmd.addCommand("PING", pingHandler);
}

void loop () 
{
  if (Serial.available() > 0)
  {
    sCmd.readSerial();
    Serial.println("PONG");
  }
}

void pingHandler (const char *command) 
{
  Serial.println("PONG");
}
