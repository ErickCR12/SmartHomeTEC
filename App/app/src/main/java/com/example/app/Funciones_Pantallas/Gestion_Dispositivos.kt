package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.app.DataBase.Registro
import com.example.app.DataBase.RegistroDBHelper
import com.example.app.R
import kotlinx.android.synthetic.main.dispositivos.*
import org.json.JSONArray
import org.json.JSONObject
import java.util.ArrayList


class Gestion_Dispositivos: AppCompatActivity() {

    //Se crea un list de dispositivos registrados y caracaterísticas
    val dispositivos_registrados = arrayListOf<String>()
    val tipos_registrados = arrayListOf<String>()
    val marcas_registrados = arrayListOf<String>()
    val series_registrados = arrayListOf<String>()
    val consumo_registrados = arrayListOf<String>()
    val garantias_registrados = arrayListOf<String>()

    val tipos_del_server = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.dispositivos)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val aposentos_re = intent.getStringArrayListExtra("aposentos")

        val usuario_re = aposentos_re.get(aposentos_re.size - 1 )

        val urlTipos = "http://192.168.1.40/API_Service/api/deviceTypes/"

        //Variables para recibir los datos de entrada de los dispositivos y sus características
        val disp_nombre = findViewById<EditText>(R.id.txtdispsotivo) as EditText
        val disp_marca = findViewById<EditText>(R.id.txtmarca) as EditText
        val disp_serie = findViewById<EditText>(R.id.txtseries) as EditText
        val disp_consumo = findViewById<EditText>(R.id.txtconsumo) as EditText
        val disp_precio = findViewById<EditText>(R.id.txtprecio) as EditText

        //disp_tipo.setText(tipos_del_server[0])

        btnagregadis.setOnClickListener {

            //Se capturan los valores de los satos registrados por el usuario
            val disp_nombre_ing = disp_nombre.text.toString()
            val disp_marca_ing = disp_marca.text.toString()
            val disp_serie_ing = disp_serie.text.toString()
            val disp_consumo_ing = disp_consumo.text.toString()
            val disp_precio_ing = disp_precio.text.toString()

            //Se agregan a un array para su control y gestión
             dispositivos_registrados.add(disp_nombre_ing)
             marcas_registrados.add(disp_marca_ing)
             series_registrados.add(disp_serie_ing)
             consumo_registrados.add(disp_consumo_ing)

            //Se limpian lo espacios para la siguiente añadidura
            disp_nombre.setText("")
            disp_marca.setText("")
            disp_serie.setText("0")
            disp_consumo.setText("0")
            disp_precio.setText("0")

            //Esta sección de códgio sireve para mostrar la información de fecha y hora
            val calendario:java.util.Calendar = java.util.Calendar.getInstance()

            //El formato es Día-Mes-Año la garantía
            val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
            val mes = calendario.get(java.util.Calendar.MONTH)
            val ano = calendario.get(java.util.Calendar.YEAR)

            /** AQUÍ SE TENDRÍA QUE RECIBIR EL MES DE GARANTÍA QUE VIENE DEL API PARA HACER EL CÁLCULO*/
            //val garantia = mes + disp_garantia_ing.toInt()

            //Se muestra la garantía del dispositivo como un Toast
            //Toast.makeText(this, "Garantía $garantia", Toast.LENGTH_LONG).show()

            //BASES DE DATOS

            val baseDatos = RegistroDBHelper(this)
            deleteDatabase(RegistroDBHelper.DATABASE_NAME)
            baseDatos.crearRegistro(
                    baseDatos.readableDatabase, Registro(
                        0,
                        usuario_re,
                        disp_nombre_ing,
                        //disp_tipo_ing,
                        disp_marca_ing,
                        disp_serie_ing.toInt()
                        //disp_nombre_ing
                    )
            )

            //Envio de datos
            val queue = Volley.newRequestQueue(this)
            val jsonObject = JSONObject()
            val url = "http://192.168.1.6/API_Service/api/devices/"

            jsonObject.put("serial_number",disp_serie_ing)
            jsonObject.put("brand", disp_nombre_ing)
            jsonObject.put("electric_usage", disp_consumo_ing)
            jsonObject.put("price", disp_precio_ing)
            jsonObject.put("device_type_name",disp_nombre_ing)


            val stringRequest = JsonObjectRequest(Request.Method.POST,
                    url, jsonObject, { response ->
            },
                    {
                        Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
            queue.add(stringRequest)
        }

        btnsiguiente.setOnClickListener {

            val intent = Intent(this, Menu::class.java)

            val urlTipos = "http://192.168.1.6/API_Service/api/deviceTypes/"

            val queue = Volley.newRequestQueue(this)

            //Validaciones para continuar en la aplicación

            val stringRequest = JsonArrayRequest(Request.Method.GET,
                urlTipos, null, { response ->

                    for (i in 0 until (response.length())) {
                        val tipo: JSONObject = response.getJSONObject(i)

                        dispositivos_registrados.add(tipo.getString("name"))
                        Log.i("for", dispositivos_registrados.toString())
                    }

                    dispositivos_registrados.add("*")

                    for (registro in 0 until aposentos_re.size) {
                        dispositivos_registrados.add(aposentos_re[registro])
                    }

                    Log.i("Dispositivos", dispositivos_registrados.toString())

                    intent.putExtra("dispositivos", dispositivos_registrados)
                    startActivity(intent)
                },

                {
                    Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()
                })

            queue.add(stringRequest)
        }
    }
}