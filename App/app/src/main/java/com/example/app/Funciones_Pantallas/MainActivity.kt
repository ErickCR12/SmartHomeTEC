package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.app.DataBase.*
import com.example.app.R
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.content_main.*
import org.json.JSONObject
import kotlin.collections.ArrayList


class MainActivity : AppCompatActivity() {

    val aposentos = arrayListOf<String>("Dormitorio", "Sala", "Cocina", "Comedor")

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(toolbar)

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputusuario) as EditText
        val contrasena_inpurt = findViewById<EditText>(R.id.inputcontrasena) as EditText

        val url = "http://192.168.1.6/API_Service/api/"
        val queue = Volley.newRequestQueue(this)
        val jsonObject = JSONObject()

        var id = 0

        //Botón de acceso a la ventana de Administrar Carrito
        btningresar.setOnClickListener {
            //Se toma el valor del usuario ingresado
            var usuario = usuario_input.text.toString()

            //Se toma el valor de la contraseña registrada
            var contrasena = contrasena_inpurt.text.toString()

            val intent = Intent(this, Menu::class.java)

            //Envio del usuario y contraseña en formato JSON
            jsonObject.put("username",usuario)
            jsonObject.put("password",contrasena)

            //Validaciones para continuar en la aplicación

            val stringRequest = JsonObjectRequest(Request.Method.POST,
            "${url}login/", jsonObject, { response ->
            if(response != null && response.get("userType").toString() == "Client"){
                response.get("username")
                response.get("password")
                response.get("userType")

                Toast.makeText(this, "BIENVENIDO",  Toast.LENGTH_LONG).show()

                val tabla_aposentos = AposentosDBHelper(this)
                val revisar_estado_inicial = tabla_aposentos.obtenerAposento(0).nombreAposento


                if (revisar_estado_inicial.isNullOrEmpty()){
                    deleteDatabase(AposentosDBHelper.DATABASE_NAME)
                    for (i in 0 until aposentos.size){
                        //Se agregan elementos a la base de datos aposentos
                        tabla_aposentos.crearAposento(tabla_aposentos.readableDatabase,
                                Aposentos(id, usuario, aposentos.get(i))
                        )
                    }
                    startActivity(intent)
                }
                else{
                    startActivity(intent)
                }
            }
            else{
            Toast.makeText(this,"DATOS INVÁLIDOS", Toast.LENGTH_LONG).show()
            }

            },
            {
            Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
            queue.add(stringRequest)

        }
    }
}
