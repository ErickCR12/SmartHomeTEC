package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Spinner
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.vinculo.*
import kotlinx.serialization.json.buildJsonObject

class Vincular: AppCompatActivity() {

    //Se crea un list de dispositivos registrados y caracaterísticas
    val vinculados = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.vinculo)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val aposento_registrados = intent.getStringArrayListExtra("dispositivos")

        val dispositivos_registrados = aposento_registrados.reversed()

        //Se sleccionan los array para el mostrarlos en los spinners
        val delimitador = Posicion("*", aposento_registrados)

        val dispositivo_re = aposento_registrados.subList(0,delimitador)
        Log.i("DISPOSITIVO", dispositivo_re.toString())

        val aposento_re = dispositivos_registrados.subList(0, delimitador+1)
        Log.i("APOSENTO", aposento_re.toString())

        //Variable para administrar el spinner con la información de aposentos y dispositivos
        //Se crea un spinner para mostar los elementos seleccionados por el usuario
        val aposentos_disp = findViewById<Spinner>(R.id.spinner_aposentos)
        val dispositivos_disp = findViewById<Spinner>(R.id.spinner_dispositivo)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val l_aposentos = ArrayAdapter(this,android.R.layout.simple_spinner_item, aposento_re)
        aposentos_disp.adapter = l_aposentos

        val l_dispositivos = ArrayAdapter(this,android.R.layout.simple_spinner_item, dispositivo_re)
        dispositivos_disp.adapter = l_dispositivos

        //Indicadores de las posiciones de los elementos vinculados
        var indicador_dispositivo = 0
        var indicador_aposento = 0

        //Seleccion de un dispositivo
        dispositivos_disp.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                indicador_dispositivo = position
            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        //Selección de un aposento
        aposentos_disp.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                indicador_aposento = position
            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        btnvincular.setOnClickListener {
            //Se añaden los nuevos valores vinculados a su respectivo array
            vinculados.add(aposento_re.get(indicador_aposento))
            vinculados.add(dispositivo_re.get(indicador_dispositivo))
            //vinculo_dispositivos.add(dispositivo_registrados.get(indicador_dispositivo))

            //Se eliminan del array original para no desplegarlos como opción otra vez
            dispositivo_re.removeAt(indicador_dispositivo)

        }

        //Se envia la iformación a la siguiente ventana
        btnsiguie.setOnClickListener {

            val intent = Intent(this, Menu::class.java)
            Log.i("VINCULO", vinculados.toString())
            intent.putExtra("vinculados", vinculados)
            startActivity(intent)
        }
    }

    private fun Posicion(elemento: String, datos: ArrayList<String>): Int {
        for (registro in 0 until datos.size) {
            if (elemento == datos.get(registro)) {
                return registro
            }
        }
        return -1
    }
}