package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.dispositivos.*


class Gestion_Dispositivos: AppCompatActivity() {


    //Se crea un list de dispositivos registrados y caracaterísticas
    val dispositivos_registrados = arrayListOf<String>()
    val tipos_registrados = arrayListOf<String>()
    val marcas_registrados = arrayListOf<String>()
    val series_registrados = arrayListOf<String>()
    val consumo_registrados = arrayListOf<String>()
    val garantias_registrados = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.dispositivos)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val informacion = intent.getStringArrayListExtra("aposentos")

        Log.i("aposentos_", informacion.toString())

        //Variables para recibir los datos de entrada de los dispositivos y sus características
        val disp_nombre = findViewById<EditText>(R.id.txtdispsotivo) as EditText
        val disp_tipo = findViewById<EditText>(R.id.txttipo) as EditText
        val disp_marca = findViewById<EditText>(R.id.txtmarca) as EditText
        val disp_serie = findViewById<EditText>(R.id.txtseries) as EditText
        val disp_consumo = findViewById<EditText>(R.id.txtconsumo) as EditText


        btnagregadis.setOnClickListener {


            //Se capturan los valores de los satos registrados por el usuario
            val disp_nombre_ing = disp_nombre.text.toString()
            val disp_tipo_ing = disp_tipo.text.toString()
            val disp_marca_ing = disp_marca.text.toString()
            val disp_serie_ing = disp_serie.text.toString()
            val disp_consumo_ing = disp_consumo.text.toString()

            //Se agregan a un array para su control y gestión
             dispositivos_registrados.add(disp_nombre_ing)
             tipos_registrados.add(disp_tipo_ing)
             marcas_registrados.add(disp_marca_ing)
             series_registrados.add(disp_serie_ing)
             consumo_registrados.add(disp_consumo_ing)

            //Se limpian lo espacios para la siguiente añadidura
            disp_nombre.setText("")
            disp_tipo.setText("")
            disp_marca.setText("")
            disp_serie.setText("")
            disp_consumo.setText("")

        }

        btnsiguiente.setOnClickListener {
            val intent = Intent(this, Vincular::class.java)
            intent.putExtra("aposentos", informacion)
            intent.putExtra("dispositivos", dispositivos_registrados)
            intent.putExtra("tipos", tipos_registrados)
            intent.putExtra("marcas", marcas_registrados)
            intent.putExtra("series", series_registrados)
            intent.putExtra("consumos", consumo_registrados)
            intent.putExtra("tiempos", garantias_registrados)
            startActivity(intent)
        }
    }
}