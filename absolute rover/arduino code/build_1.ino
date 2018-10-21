#include "DHT.h"
#include <SoftwareSerial.h>

#define DHTPIN A4
#define DHTTYPE DHT21  
SoftwareSerial GPS(A5, A6);
unsigned char buffer[64]; // buffer
int count=0;
int echoPin = 9; 
int trigPin = 8; 
int a=6;
int b=7;
int mus=A1;
int fair=A0;
int led=A3;
int rsense= A7;
int curCounter= 0;
DHT dht(DHTPIN, DHTTYPE);
SoftwareSerial mySerial(12,11); // RX, TX
int reh=10;
int MotorLeftActiv = 4;//Вперед или назад левый двигатель
int MotorLeftSpeed = 5;//Скорость левого двигателя
int MotorRightActic = 2;//Вперед или назад правый двигатель
int MotorRightSpeed = 3;//Скорость правого двигателя
void gps(){
     if (GPS.available())
    {
        while(GPS.available())
        {
            buffer[count++]=GPS.read();
            if(count == 64)
            break;
        }
        mySerial.write(buffer,count);
        mySerial.println();
        clrBuff();
        count = 0;
    }
}
void clrBuff()
{
    for (int i=0; i<count;i++)
    {
        buffer[i]=NULL;
    }
}
int Skorost = 200;//Скорость

void Vpered(int Speed)//Двигаться вперед
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,Speed);
}
void sonar (){
  int duration, cm, inch, mm; 
  digitalWrite(trigPin, LOW); 
  delayMicroseconds(2); 
  digitalWrite(trigPin, HIGH); 
  delayMicroseconds(10); 
  digitalWrite(trigPin, LOW); 
  duration = pulseIn(echoPin, HIGH); 
  cm = duration / 58;
  inch = duration / 148;
  mm = duration / 5.8;
   mySerial.print(cm); 
   mySerial.print(" cm   "); 
   mySerial.print(inch);
   mySerial.print(" inch   ");
   mySerial.print(mm); 
   mySerial.println(" mm   ");
  
}
void Nazad(int Speed)//Двигаться назад
{
  digitalWrite(MotorLeftActiv,HIGH);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,HIGH );
  analogWrite(MotorRightSpeed,Speed);
}
bool zax=true;
String s;
void BlutControl()
{
  char val;
 

  if (mySerial.available()>0) {
    
    val = mySerial.read();//Прочитать байт с блютуза
   
  }
 
    switch (val) {
      case 'F':    // F - в перед
        Vpered(Skorost);//Двигаться вперед
        Serial.write(val); 
        break;
      case 'B':    // B - назад
        Nazad(Skorost);//Двигаться назад
        Serial.write(val); 
        break;
      case 'L':    // L - лево
        NamesteVlevo(Skorost);//Вращаться на месте влево
        Serial.write(val); 
        break;
      case 'R':    // R - право
        NamesteVpravo(Skorost);//Вращаться на месте вправо
        Serial.write(val); 
        break;
      case 'G':    // G - в перед в лево
        VlevoVperet(Skorost);//Двигаться вперед влево
        Serial.write(val); 
        break;
      case 'I':    // I - в перед в право
        VpravoVperet(Skorost);//Двигаться вперед вправо
        Serial.write(val);
        break;
      case 'H':    // H - Назад в лево
        VlevoNazad(Skorost);//Двигаться назад влево
        Serial.write(val);
        break;
      case 'J':    // J - назад в право
        VpravoNazad(Skorost);//Двигаться назад вправо
        Serial.write(val);
        break;
      case 'S':    // S - стоп
        Stop();//Остановиться
        break;
      case 'W':    // W - передние огни вкл
       digitalWrite (led,HIGH);
        break;
      case 'w':    // w - передние огни выкл
         digitalWrite (led,LOW);
        break;
      case 'U':    // U - задние огни вкл
       gps();
        break;
      case 'u':    // u - задние огни выкл
      gps();
        break;
        
      case 'V':    // V - сигнал вкл
      digitalWrite (mus,HIGH);
        sos();
        break;
      case 'v':    // v - сигнал выкл
         digitalWrite (mus,LOW);
        ok();
        break;
      case 'X':    // X - габариты вкл 
        // statements
 was();
        break;
      case 'x':    // x - габариты выкл
        // statements
      was();
        break;  
      case 'D':    // x - габариты выкл
        // statements
      sonar();
        break;
      case 'd':    // x - габариты выкл
        // statements
      sonar();
        break;
      case '0':    // 0 - скорость 0
        Skorost = 0;// statements
        Serial.write(val); 
        break;
      case '1':    // 1 - скорость 10
        Skorost = 50;// statements
        Serial.write(val); 
        break;
      case '2':    // 2 - скорость 20
        Skorost = 80;// statements
        Serial.write(val); 
        break;
      case '3':    // 3 - скорость 30
        Skorost = 100;// statements
        Serial.write(val); 
        break;
      case '4':    // 4 - скорость 40
        Skorost = 120;// statements
        Serial.write(val); 
        break;
      case '5':    // 5 - скорость 50
        Skorost = 140;// statements
        Serial.write(val); 
        break;
      case '6':    // 6 - скорость 60
        Skorost = 160;// statements
        Serial.write(val); 
        break;
      case '7':    // 7 - скорость 70
        Skorost = 180;// statements
        Serial.write(val); 
        break;
      case '8':    // 8 - скорость 80
        Skorost = 210;// statements
        Serial.write(val); 
        break;
      case '9':    // 9 - скорость 90
        Skorost = 240;
        Serial.write(val); 
        break;
      case 'q':    // q - скорость 100
        Skorost = 255;
        Serial.write(val); 
        break;
     // default: 
        // statements
    }
}

void Stop()//Остановиться
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,0);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,0);
}

void VlevoVperet(int Speed)//Двигаться вперед влево
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,0);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,Speed);
}

void VpravoVperet(int Speed)//Двигаться вперед вправо
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,0);
}

void VlevoNazad(int Speed)//Двигаться назад влево
{
  digitalWrite(MotorLeftActiv,HIGH);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,0);
}

void VpravoNazad(int Speed)//Двигаться назад вправо
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,0);
  digitalWrite(MotorRightActic,HIGH);
  analogWrite(MotorRightSpeed,Speed);
}

void NamesteVlevo(int Speed)//Вращаться на месте влево
{
  digitalWrite(MotorLeftActiv,HIGH);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,LOW);
  analogWrite(MotorRightSpeed,Speed);
}

void NamesteVpravo(int Speed)//Вращаться на месте вправо
{
  digitalWrite(MotorLeftActiv,LOW);
  analogWrite(MotorLeftSpeed,Speed);
  digitalWrite(MotorRightActic,HIGH);
  analogWrite(MotorRightSpeed,Speed);
}
void sos(){

   mySerial.println ("*** ––– ***");

}
void ok(){

   mySerial.println ("--- –*–");
}
void was(){
   int rsread= analogRead (rsense);
   int fairr=analogRead(fair);
   mySerial.print ("Rain intensity: ");
  if(rsread<=300){
    
       mySerial.print(rsread);
     
         mySerial.println(" wetly");
  }
  else{
    
       mySerial.println(rsread);
  }
  
  int rehVal=digitalRead (reh);
   float h = dht.readHumidity();
  float t = dht.readTemperature();
   if (isnan(t) || isnan(h)) {
  
    mySerial.println("Failed to read from DHT");
  } else {
    
  
   
     mySerial.print("Temperature: "); 
       mySerial.print(t);
  
        mySerial.println(" *C");
   
     mySerial.print("Humidity: "); 
   mySerial.print(h);
   mySerial.println(" %");
  }
  if(rehVal==HIGH){
  
  
     mySerial.println("Barrier: no ");

  }
  else{
  
  
        mySerial.println("Barrier: yes");


  }
   int ar=digitalRead(a);
  int br=digitalRead (b);
  if(ar==LOW && br==LOW){

  mySerial.println("Degree of pollution: Green (0)");
 
  }
  else if(ar==HIGH && br==LOW){
 
  mySerial.println("Degree of pollution: Yellow (1)");  
  
  }
    if(ar==LOW && br==HIGH){
 
   mySerial.println("Degree of pollution: Orange (2)");
   
  }
    if(ar==HIGH && br==HIGH){
  
    mySerial.println("Degree of pollution: Red (3)");
    
  }
   mySerial.print ("CO analyze: ");
   mySerial.println (fairr);
  sonar();
  
}

void setup() {
pinMode (fair,INPUT);
pinMode (A4,INPUT);
   pinMode (rsense,INPUT);  
      pinMode (a,INPUT);   
        pinMode (b,INPUT);      
pinMode (reh,INPUT);
 pinMode(trigPin, OUTPUT); 
  pinMode(echoPin, INPUT);
mySerial.begin(9600);
GPS.begin(9600);
 pinMode(led, OUTPUT);
 pinMode(mus, OUTPUT);
pinMode(MotorLeftActiv, OUTPUT);
  pinMode(MotorLeftSpeed, OUTPUT);
  pinMode(MotorRightSpeed, OUTPUT);
  pinMode(MotorRightActic, OUTPUT);
}
float tl=0;


void loop() {

  BlutControl();

}
