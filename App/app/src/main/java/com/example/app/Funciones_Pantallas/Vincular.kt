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
    val vinculo_aposentos = arrayListOf<String>()
    val vinculo_dispositivos = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.vinculo)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val aposento_registrados = intent.getStringArrayListExtra("aposentos")
        val dispositivo_registrados = intent.getStringArrayListExtra("dispositivos")

        //Variable para administrar el spinner con la información de aposentos y dispositivos
        //Se crea un spinner para mostar los elementos seleccionados por el usuario
        val aposentos_disp = findViewById<Spinner>(R.id.spinner_dispositivo)
        val dispositivos_disp = findViewById<Spinner>(R.id.spinner_aposentos)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val l_aposentos = ArrayAdapter(this,android.R.layout.simple_spinner_item, aposento_registrados)
        aposentos_disp.adapter = l_aposentos

        val l_dispositivos = ArrayAdapter(this,android.R.layout.simple_spinner_item, dispositivo_registrados)
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
            Log.i("aposento", indicador_aposento.toString())
            Log.i("dispositivo", indicador_dispositivo.toString())

            //Se añaden los nuevos valores vinculados a su respectivo array
            vinculo_aposentos.add(aposento_registrados.get(indicador_aposento))
            vinculo_dispositivos.add(dispositivo_registrados.get(indicador_dispositivo))

            //Se eliminan del array original para no desplegarlos como opción otra vez
            dispositivo_registrados.removeAt(indicador_dispositivo)
        }

        //Se envia la iformación a la siguiente ventana
        btnsiguie.setOnClickListener {
            val intent = Intent(this, Control::class.java)
            intent.putExtra("aposentos_vi", vinculo_aposentos)
            intent.putExtra("dispositivos_vi", vinculo_dispositivos)
            startActivity(intent)
        }
    }
}