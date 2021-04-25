package com.example.app.Funciones_Pantallas

import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R

class Control: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.control)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val aposento_registrados = intent.getStringArrayListExtra("aposentos_vi")
        val dispositivo_registrados = intent.getStringArrayListExtra("dispositivos_vi")

        Log.i("aposentos_", aposento_registrados.toString())
        Log.i("dispositivos_", dispositivo_registrados.toString())

    }
}