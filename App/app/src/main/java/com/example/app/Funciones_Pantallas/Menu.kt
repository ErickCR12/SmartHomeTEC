package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.Volley
import com.example.app.DataBase.Aposentos
import com.example.app.DataBase.AposentosDBHelper
import com.example.app.DataBase.RegistroDBHelper
import com.example.app.R
import kotlinx.android.synthetic.main.menu.*
import org.json.JSONObject

class Menu: AppCompatActivity() {

    val dispositivos_registrados = arrayListOf<String>()

    val dispositivos_informacion = arrayListOf<String>()
    val aposentos_informacion_i = arrayListOf<String>()

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.menu)

        val tabla_aposentos = AposentosDBHelper(this)
        val usuario = tabla_aposentos.obtenerAposento(0).nombreUsuario

      //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        var aposentos_informacion = intent.getStringArrayListExtra("aposentos")
        var vinculaciones = intent.getStringArrayListExtra("vinculados")


        //Botón para la ventana de aposentos
        btnmenu.setOnClickListener {
            val intentt = Intent(this, Gestion_Aposentos::class.java)
            intentt.putExtra("usuario", usuario)
            startActivity(intentt)
        }

        //Botón para la ventana de dispositivos
        btnmenu1.setOnClickListener {

            //Hacer el request para enviar la traer la información de dispositivos

            val intent2 = Intent(this, Gestion_Dispositivos::class.java)
            val urlTipos = "http://192.168.1.6/API_Service/api/deviceTypes/"
            val queue = Volley.newRequestQueue(this)

            val stringRequest = JsonArrayRequest(Request.Method.GET,
                    urlTipos, null, { response ->

                for (i in 0 until (response.length())) {

                    val tipo: JSONObject = response.getJSONObject(i)
                    dispositivos_registrados.add(tipo.getString("name"))
                }
                //Se debe enviar el usuario que utilice la aplicación en dicho momento
                dispositivos_registrados.add(usuario)

                intent2.putExtra("dispositivos", dispositivos_registrados)
                startActivity(intent2)
                },
                    {
                        Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()
                    })
            queue.add(stringRequest)
        }

        //Botón para la ventana de vincular
        btnmenu2.setOnClickListener {

            //Se debe hacer otro vinculo aquí para extraer el tipo de dispostivo y la serie
            //además de extraer los aposentos para la ventana vincular

            //
            val urlTipos = "http://192.168.1.6/API_Service/api/devices/byclient/" + usuario

            Log.i("TIPO", urlTipos)

            val queue = Volley.newRequestQueue(this)
            val intent3 = Intent(this, Vincular::class.java)

            val stringRequest = JsonArrayRequest(Request.Method.GET,
                    urlTipos, null, { response ->

                for (i in 0 until (response.length())) {

                    val tipo: JSONObject = response.getJSONObject(i)
                    val elemento_a_guardar =  tipo.getString("device_type_name") + tipo.getInt("serial_number").toString()
                    dispositivos_informacion.add(elemento_a_guardar )
                }

                //Manejo de los aposentos
                val tabla_aposentos = AposentosDBHelper(this)

                for (i in 0 until  tabla_aposentos.getListaAposentos(0).size ){
                    aposentos_informacion_i.add( tabla_aposentos.getListaAposentos(0)[i].nombreAposento)
                }

                intent3.putExtra("dispositivos", dispositivos_informacion)
                intent3.putExtra("aposentos", aposentos_informacion_i)
                startActivity(intent3)
            },
                    {
                        Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()
                    })
            queue.add(stringRequest)
        }

        //Botón para la ventana de vincular
        btnmenu3.setOnClickListener {
            if (vinculaciones.isNullOrEmpty()){
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