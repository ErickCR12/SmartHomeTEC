package com.example.app.Funciones_Pantallas

import android.annotation.SuppressLint
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.aposentos.*

class Gestion_Aposentos: AppCompatActivity() {

    //Se crea un list de aposentos registrados
    val aposentos_registrados = mutableListOf<String>()

    @SuppressLint("SetTextI18n")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.aposentos)

        //Variables para recibir los datos de entrada de los aposentos
        val aposento_nombre = findViewById<EditText>(R.id.txtaposentonombre) as EditText

        var aposento:String

        /**
        menu.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            //Función implementada cuando es seleccionado uno de los elementos del spinner de platillos
            //El elemento importante es el id, ya que este dará la posición en el array de opciones
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {

                //Se selecciona el elemento del usuario y se procede a mostrarlo en la interfaz
                val seleccion = platillos_recibidos[position].toString()
                val seleccion2 = precio_recibidos[position].toString()
                item.setText(seleccion)
                //total.setText(seleccion2)

                costoinidividual = precio_recibidos[position].toString().toInt()

                tiempo_pre = tiempo_recibidos[position].toString().toInt()

                indice = position
            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        **/

        //Botón para añadir aposentos a la aplicación
        btnanadir.setOnClickListener {
            btneliminar2.isEnabled = false
            //Se toma el nombre del registro del aposento ingresado por el usuario
             aposento = aposento_nombre.text.toString()
            //Si no se añade ningún aposento registrado se añaden por default
            //dormitorio, cocina, sala, comedor
            if (aposento_nombre.text.toString().isNullOrEmpty()){
                aposentos_registrados.add("dormitorio")
                aposentos_registrados.add("cocina")
                aposentos_registrados.add("sala")
                aposentos_registrados.add("comedor")
                Log.i("info", aposentos_registrados.toString())
            }
            else{
                //Si el usuario ingresa un aposento válido se añade a la lista vacia
                aposentos_registrados.add(aposento)
                Log.i("info", aposentos_registrados.toString())
            }
        }

        //Botón para eliminar aposentos a la aplicación
        btneliminar2.setOnClickListener {
            aposento_nombre.setText("Eliminar Aposento")
            //Se toma el nombre del registro del aposento ingresado por el usuario
            aposento = aposento_nombre.text.toString()
            //Se elimina el elemento registrado por el usuario
            aposentos_registrados.remove(aposento)

            Log.i("info", aposentos_registrados.toString())
        }

        btneditar.setOnClickListener {  }

        //Botón para consultar los aposentos de la aplicación
        btnconsulta.setOnClickListener {  }
        Log.i("info", aposentos_registrados.toString())
    }

    private fun Posicion(elemento: String, datos: List<String>): Int {
        for (registro in 0 until datos.size){
            if (elemento == datos.get(registro)){
                return registro
            }
        }
        return -1
    }
}