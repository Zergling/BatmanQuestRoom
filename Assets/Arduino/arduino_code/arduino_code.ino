#include <SoftwareSerial.h>
#include <SerialCommand.h>
SerialCommand sCmd;

void setup() 
{
  Serial.begin(9600);
  while (!Serial);

  analogWrite(A4, 255);
}

void loop () 
{
  if (Serial.available() > 0)
  {
    sCmd.readSerial();
    Serial.println("PONG");
    analogWrite(A4, 255);
    delay(5000);
    analogWrite(A4, 0);
  }
}
