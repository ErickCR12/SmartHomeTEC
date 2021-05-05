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
        val intent = getIntent()
        var aposentos_informacion = intent.getStringArrayListExtra("aposentos")
        var dispositivos_informacion = intent.getStringArrayListExtra("dispositivos")
        var vinculaciones = intent.getStringArrayListExtra("vinculados")


        btnmenu.setOnClickListener {
            startActivity(Intent(this, Gestion_Aposentos::class.java))
        }

        btnmenu1.setOnClickListener {
            val intent2 = Intent(this, Gestion_Dispositivos::class.java)
            intent2.putExtra("aposentos", aposentos_informacion)
            startActivity(intent2)
        }

        btnmenu2.setOnClickListener {
            val intent3 = Intent(this, Vincular::class.java)
            intent3.putExtra("dispositivos", dispositivos_informacion)
            startActivity(intent3)
        }

        btnmenu3.setOnClickListener {
            val intent4 = Intent(this, Control::class.java)
            intent4.putExtra("vinculados", vinculaciones)
            startActivity(intent4)
        }

    }

}