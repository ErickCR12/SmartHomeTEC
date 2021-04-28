package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.menu.*

class Menu: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.menu)


        //Se recibe la información de los aposentos registrados de al ventana anterior
        //val intent = getIntent()
        //var aposentos_informacion = intent.getStringArrayListExtra("aposentos")
        //var dispositivos_informacion = intent.getStringArrayListExtra("dispositivos")
        //var aposento_registrados_informacion = intent.getStringArrayListExtra("aposentos_vi")
        //var dispositivo_registrados_informacion = intent.getStringArrayListExtra("dispositivos_vi")

        btnmenu.setOnClickListener {
            startActivity(Intent(this, Gestion_Aposentos::class.java))
        }

        btnmenu1.setOnClickListener {
            val intent = Intent(this, Vincular::class.java)
            //intent.putExtra("aposentos", aposentos_informacion)
            startActivity(Intent(this, Gestion_Dispositivos::class.java))
        }

        btnmenu2.setOnClickListener {
            val intent = getIntent()
            val aposento_registrados = intent.getStringArrayListExtra("aposentos")
            val dispositivo_registrados = intent.getStringArrayListExtra("dispositivos")
            //val intent = Intent(this, Vincular::class.java)
            //intent.putExtra("aposentos", aposentos_informacion)
            //intent.putExtra("dispositivos", dispositivos_informacion)
            //startActivity(intent)
        }

        btnmenu3.setOnClickListener {
            //Log.i("APOSENTOS", aposentos_informacion.toString())
            //Log.i("DISPOSITIVOS", dispositivos_informacion.toString())
            //val intent = Intent(this, Control::class.java)
            //intent.putExtra("aposentos_vi", aposento_registrados_informacion)
            //intent.putExtra("dispositivos_vi", dispositivo_registrados_informacion)
            //startActivity(intent)
        }

    }

}