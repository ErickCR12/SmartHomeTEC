package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.menu.*

class Menu: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.menu)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val usuario = intent.getStringExtra("usuario")
        var aposentos_informacion = intent.getStringArrayListExtra("aposentos")
        var dispositivos_informacion = intent.getStringArrayListExtra("dispositivos")
        var vinculaciones = intent.getStringArrayListExtra("vinculados")

        btnmenu.setOnClickListener {
            val intentt = Intent(this, Gestion_Aposentos::class.java)
            intentt.putExtra("usuario", usuario)
            startActivity(intentt)
        }

        btnmenu1.setOnClickListener {
            if (aposentos_informacion.size == 0 || aposentos_informacion == null){
                Toast.makeText(this, "Favor seleccionar los aposentos", Toast.LENGTH_LONG).show()
            }
            else {
                val intent2 = Intent(this, Gestion_Dispositivos::class.java)
                intent2.putExtra("aposentos", aposentos_informacion)
                startActivity(intent2)
            }
        }

        btnmenu2.setOnClickListener {
            if (dispositivos_informacion.size == 0 ){
                Toast.makeText(this, "Favor seleccionar los dispositivos", Toast.LENGTH_LONG).show()
            }
            else {
                val intent3 = Intent(this, Vincular::class.java)
                intent3.putExtra("dispositivos", dispositivos_informacion)
                startActivity(intent3)
            }
        }

        btnmenu3.setOnClickListener {
            if (vinculaciones.size == 0 || vinculaciones == null){
                Toast.makeText(this, "Debe vincular dispositivos", Toast.LENGTH_LONG).show()
            }
            else {
                val intent4 = Intent(this, Control::class.java)
                intent4.putExtra("vinculados", vinculaciones)
                startActivity(intent4)
            }
        }
    }
}