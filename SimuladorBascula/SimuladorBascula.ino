/*
 Name:		SimuladorBascula.ino
 Created:	23/01/2018 17:21:30
 Author:	HSALINAS
*/
#include <TimerOne.h>

volatile int Contador;
volatile long TimerValue;
volatile double PesoBas;

// the setup function runs once when you press reset or power the board
void setup() {
	// put your setup code here, to run once:
	pinMode(13, OUTPUT); // Salida
	pinMode(2, INPUT);   // Entrada
						 // Configurar pullDown
	digitalWrite(2, LOW);

	//Configuracion del puerto com
	Serial.begin(9600);  // Inicializa el pueto a los Bauds configurados
	Serial.setTimeout(20);
	//Configurar Interrupcion

	attachInterrupt(0, Interrupt, FALLING);

	// Configurar Timer del simulador de bascula
	PesoBas = 0;
	Timer1.initialize(1500000);
	Timer1.attachInterrupt(CambiarPeso);
}

void CambiarPeso() {
	PesoBas = random(1, 500) / 100.00;
}

// Tarea que se realiza al recibir el pulso en el pin 2 Int0.
void Interrupt() {
	if (millis()>TimerValue + 10) {
		Contador++;
		TimerValue = millis();
	}
}

// Tarea de lectura del puerto serie
void serialEvent() {
	while (Serial.available()) {
		String incoming = Serial.readString();
		//Serial.print("Recibí: ");
		//Serial.println(incoming);

		if (incoming == "LC") {       // Leer Contador
			Serial.println(Contador);
		}
		else if (incoming == "LB") { // Leer Bascula
			Serial.print("ST,GS,+   ");
			Serial.print(PesoBas);
			Serial.println("kg");
		}
		else if (incoming == "RC") { // Reset Contador
			Contador = 0;
			Serial.println(Contador);
		}
		else if (incoming == "RB") { // Reset Bascula
			PesoBas = 0;
			Serial.print("ST,GS,+   ");
			Serial.print(PesoBas);
			Serial.println("kg");
		}
		else {                      // Sin Funcion
			Serial.println("");
		}

	}
}

// the loop function runs over and over again until power down or reset
void loop() {
  
}
