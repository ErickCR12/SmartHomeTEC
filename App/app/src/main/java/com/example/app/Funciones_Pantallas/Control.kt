package com.example.app.Funciones_Pantallas

import android.os.Build
import android.os.Bundle
import android.util.Log
import android.widget.TextView
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.app.DataBase.Historial
import com.example.app.DataBase.HistorialDBHelper
import com.example.app.DataBase.Registro
import com.example.app.DataBase.RegistroDBHelper
import com.example.app.R
import kotlinx.android.synthetic.main.control.*
import org.json.JSONObject
import java.time.LocalDateTime

class Control: AppCompatActivity() {

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.control)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val vinculados_registrados = intent.getStringArrayListExtra("vinculados")

        val tabla_vinculaciones = RegistroDBHelper(this)


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

        //Esta sección de códgio sireve para mostrar la información de fecha y hora
        val calendario:java.util.Calendar = java.util.Calendar.getInstance()

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
        btnsalir.setOnClickListener{
            this.finish()
        }

        swinterruptor.setOnCheckedChangeListener{_, isChecked ->
            //El formato es Día-Mes-Año la garantía
            val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
            val mes = calendario.get(java.util.Calendar.MONTH)
            val ano = calendario.get(java.util.Calendar.YEAR)
            val hora = calendario.get(java.util.Calendar.HOUR)
            val minuto = calendario.get(java.util.Calendar.MINUTE)

            //Envio de datos
            val queue = Volley.newRequestQueue(this)
            val jsonObject = JSONObject()
            val url = "http://192.168.1.6/API_Service/api/devices/state"

            jsonObject.put("serial_number",tabla_vinculaciones.getListaRegistro(0)[item].serieDispositivo)
            jsonObject.put("action", "Encender")
            jsonObject.put("minutes_action", 45)
            jsonObject.put("date","$ano/$mes/$dia")
            jsonObject.put("time", "$hora:$minuto")

            val stringRequest = JsonObjectRequest(Request.Method.POST,
                    url, jsonObject, { response ->
            },
                    {
                        Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
            queue.add(stringRequest)
            if (isChecked){
                swinterruptor.text = "ENCENDIDO"
                //Envio de datos
                val queue = Volley.newRequestQueue(this)
                val jsonObject = JSONObject()
                val url = "http://192.168.1.6/API_Service/api/devices/state"

                jsonObject.put("serial_number",tabla_vinculaciones.getListaRegistro(0)[item].serieDispositivo)
                jsonObject.put("action", "Encender")
                jsonObject.put("minutes_action", minuto)
                jsonObject.put("date","$ano/$mes/$dia")
                jsonObject.put("time", "$hora:$minuto")

                val stringRequest = JsonObjectRequest(Request.Method.POST,
                        url, jsonObject, { response ->
                },
                        {
                            Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
                queue.add(stringRequest)
            }

            else{
                //Envio de datos
                val queue = Volley.newRequestQueue(this)
                val jsonObject = JSONObject()
                val url = "http://192.168.1.6/API_Service/api/devices/state"

                jsonObject.put("serial_number",tabla_vinculaciones.getListaRegistro(0)[item].serieDispositivo)
                jsonObject.put("action", "Encender")
                jsonObject.put("minutes_action", minuto)
                jsonObject.put("date","$ano/$mes/$dia")
                jsonObject.put("time", "$hora:$minuto")

                val stringRequest = JsonObjectRequest(Request.Method.POST,
                        url, jsonObject, { response ->
                },
                        {
                            Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
                queue.add(stringRequest)
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