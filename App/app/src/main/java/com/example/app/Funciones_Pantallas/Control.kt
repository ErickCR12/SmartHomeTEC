package com.example.app.Funciones_Pantallas

import android.os.Bundle
import android.util.Log
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R

class Control: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.control)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val vinculados_registrados = intent.getStringArrayListExtra("vinculados")

        Log.i("vinculados_", vinculados_registrados.toString())

        //Label para mostrar el dispositvo y el aposento vinculados
        val label_dispositivo  = findViewById<TextView>(R.id.lbldispositivo) as TextView
        val label_aposento  = findViewById<TextView>(R.id.lblaposento) as TextView

        //Se lleva un conteo de la información
        val total_vinculados = vinculados_registrados.size

        var item = 0

        //Se muestra la información de los labels
        label_aposento.setText(vinculados_registrados.get(item))
        label_dispositivo.setText(vinculados_registrados.get(1))
    }
}