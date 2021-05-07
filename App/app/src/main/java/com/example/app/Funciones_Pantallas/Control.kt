package com.example.app.Funciones_Pantallas

import android.os.Bundle
import android.util.Log
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.control.*

class Control: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.control)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val vinculados_registrados = intent.getStringArrayListExtra("vinculados")

        Log.i("vinculados_", vinculados_registrados.toString())

        //Se toman los dispositivos y aposentos del array vinculados
        //Se muestran en la pantalla de forma dispositivo/aposento
        val dispositivos_vinculados = SelccionarDispositivos(vinculados_registrados)
        val aposentos_vinculados = SelccionarAposentos(vinculados_registrados)

        //Label para mostrar el dispositvo y el aposento vinculados
        val label_dispositivo  = findViewById<TextView>(R.id.lbldispositivo) as TextView
        val label_aposento  = findViewById<TextView>(R.id.lblaposento) as TextView

        //Se lleva un conteo de la información
        val total_vinculados = vinculados_registrados.size

        //Variable para llevar el control de las posiciones en el array
        var item = 0

        //Se muestra la información de los labels
        label_aposento.setText(aposentos_vinculados.get(item))
        label_dispositivo.setText(dispositivos_vinculados.get(item))

        //Botón para retroceder a lo largo de los dispositivos disponibles
        btnretroceder.setOnClickListener {
            if (item <= 0){
                item = total_vinculados
            }
            else{
                //Se despliegan la información en los labels según el item actual
                item--
                lbldispositivo.setText(dispositivos_vinculados.get(item))
                lblaposento.setText(aposentos_vinculados.get(item))
            }
        }

        //Botón para avanzar a lo largo de los dispositivos disponibles
        btnsiguiente.setOnClickListener {
            if (item >= total_vinculados){
                item = 0
            }
            else{
                //Se despliegan la información en los labels según el item actual
                item++
                lbldispositivo.setText(dispositivos_vinculados.get(item))
                lblaposento.setText(aposentos_vinculados.get(item))
            }
        }

        swinterruptor.setOnCheckedChangeListener{_, isChecked ->
            if (isChecked){
                swinterruptor.text = "ENCENDIDO"
            }
            else{
                swinterruptor.text = "APAGADO"
            }
        }
    }

    //Funcipon para tomar los dispositivos del array vinculados, con indice par
    private fun SelccionarDispositivos(elementos: ArrayList<String>): ArrayList<String>{
        val dispositivos_array = arrayListOf<String>()
        for (registro in 0 until elementos.size) {
            if (registro%2 == 0) {
                dispositivos_array.add(elementos.get(registro))
            }
        }
        return dispositivos_array
    }

    //Funcipon para tomar los aposentos del array vinculados, con indice impar
    private fun SelccionarAposentos(elementos: ArrayList<String>): ArrayList<String>{
        val aposentos_array = arrayListOf<String>()
        for (registro in 0 until elementos.size) {
            if (registro%2 != 0) {
                aposentos_array.add(elementos.get(registro))
            }
        }
        return aposentos_array
    }


}