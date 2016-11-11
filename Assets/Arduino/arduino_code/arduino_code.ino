#include <SoftwareSerial.h>
#include <SerialCommand.h>
SerialCommand sCmd;

void setup() 
{
  Serial.begin(9600);
  while (!Serial);

  analogWrite(A4, 0);
  
  //digitalWrite(A4, HIGH);
  //digitalWrite(A4, LOW);

  //sCmd.addCommand("PING", pingHandler);
}

void loop () 
{
    /*analogWrite(A4, 255);
    delay(5000);
    analogWrite(A4, 0);
    delay(5000);*/
  
  if (Serial.available() > 0)
  {
    sCmd.readSerial();
    Serial.println("PONG");
    analogWrite(A4, 255);
    delay(5000);
    analogWrite(A4, 0);
  }
}

void pingHandler (const char *command) 
{
  Serial.println("PONG");
}
