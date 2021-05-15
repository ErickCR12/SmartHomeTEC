package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.*
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.app.DataBase.AposentosDBHelper
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
    val marcas_registrados = arrayListOf<String>()
    val series_registrados = arrayListOf<String>()
    val consumo_registrados = arrayListOf<String>()

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.dispositivos)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val dispotivos_re = intent.getStringArrayListExtra("dispositivos")

        //Se toma el correo del usuario ingresado en la apliación
        val tabla_aposentos = AposentosDBHelper(this)
        val usuario_re = tabla_aposentos.obtenerAposento(0).nombreUsuario

        //Lista de dispositivos
        val lista_dispositivos = dispotivos_re.subList(0, dispotivos_re.size -1)

        //Indidicador de posicion para el spinner seleccionado
        var indicador = 0

        //Variables para recibir los datos de entrada de los dispositivos y sus características
        val disp_nombre = findViewById<EditText>(R.id.txtdispsotivo) as EditText
        val disp_marca = findViewById<EditText>(R.id.txtmarca) as EditText
        val disp_serie = findViewById<EditText>(R.id.txtseries) as EditText
        val disp_consumo = findViewById<EditText>(R.id.txtconsumo) as EditText

        //Variable para el spinner
        val tipos_disp = findViewById<Spinner>(R.id.spntipos)

        val l_tipos = ArrayAdapter(this,android.R.layout.simple_spinner_item, lista_dispositivos)
        tipos_disp.adapter = l_tipos

        //Seccion de trabajo para el spinner en la interfaz
        tipos_disp.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                indicador = position
            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        btnagregadis.setOnClickListener {

            //Se capturan los valores de los satos registrados por el usuario
            val disp_nombre_ing = dispotivos_re.get(indicador)
            val disp_marca_ing = disp_marca.text.toString()
            val disp_serie_ing = disp_serie.text.toString()
            val disp_consumo_ing = disp_consumo.text.toString()

            //Se agregan a un array para su control y gestión
             dispositivos_registrados.add(disp_nombre_ing)
             marcas_registrados.add(disp_marca_ing)
             series_registrados.add(disp_serie_ing)
             consumo_registrados.add(disp_consumo_ing)

            //Se limpian lo espacios para la siguiente añadidura
            disp_nombre.setText("")
            disp_marca.setText("")
            disp_serie.setText("")
            disp_consumo.setText("")

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
                        disp_marca_ing,
                        disp_serie_ing.toInt()
                    )
            )

            //Envio de datos
            val queue = Volley.newRequestQueue(this)
            val jsonObject = JSONObject()
            val url = "http://192.168.1.6/API_Service/api/devices/"

            jsonObject.put("serial_number",disp_serie_ing)
            jsonObject.put("brand", disp_marca_ing)
            jsonObject.put("electric_usage", disp_consumo_ing)
            jsonObject.put("device_type_name",disp_nombre_ing)
            jsonObject.put("client_email", usuario_re)

            val stringRequest = JsonObjectRequest(Request.Method.POST,
                    url, jsonObject, { response ->
            },
                    {
                        Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
            queue.add(stringRequest)
        }


        //Se regresa al menú principal
        btnsiguiente.setOnClickListener {
            val intent = Intent(this, Menu::class.java)
            startActivity(intent)
        }
    }
}