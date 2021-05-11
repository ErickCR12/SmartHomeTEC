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
import com.example.app.R
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.content_main.*
import org.json.JSONObject
import kotlin.collections.ArrayList


class MainActivity : AppCompatActivity() {


    //Se crea un list de usuarios temporales
    val usuarios_registrados = mutableListOf("Eric", "Jarod", "Joshua", "Usuario")

    //Se crea un lista de contraseña segistradas
    val contrasenas_registradas = mutableListOf("rest", "web", "mobil", "Contraseña")

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(toolbar)

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputusuario) as EditText
        val contrasena_inpurt = findViewById<EditText>(R.id.inputcontrasena) as EditText

        val url = "http://192.168.1.40/API_Service/api/"
        val queue = Volley.newRequestQueue(this)
        val jsonObject = JSONObject()

        //Botón de acceso a la ventana de Administrar Carrito
        btningresar.setOnClickListener {
            //Se toma el valor del usuario ingresado
            var usuario = usuario_input.text.toString()

            //Se toma el valor de la contraseña registrada
            var contrasena = contrasena_inpurt.text.toString()

            /**


            //ESTA PARTE SE COMENTA PARA HACER PRUEBAS DE BASES DE DATOS

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

                val intent = Intent(this, Menu::class.java)
                intent.putExtra("usuario", response.get("username").toString())

                startActivity(intent)
            }
            else{
            Toast.makeText(this,"DATOS INVÁLIDOS", Toast.LENGTH_LONG).show()
            }

            },
            {
            Toast.makeText(this,it.toString(), Toast.LENGTH_LONG).show()})
            queue.add(stringRequest)

            //HASTA ESTA PARTE LLEGA LO DE HACER REQUEST PARA EL API


            **/

            //SIN HACER REQUEST DEL API



            //Si el usuario no ha ingresado ningún dato de entrada
            if (usuario_input.text.toString().isNullOrEmpty() || contrasena_inpurt.text.toString().isNullOrEmpty()) {
                //Se despliega un mensaje de alerta solicitando datos válidos para el ingreso
                Toast.makeText(this, "Favor ingresar datos válidos", Toast.LENGTH_LONG).show()
            } else {
                if (Corroborar(usuario, usuarios_registrados) && Corroborar(contrasena, contrasenas_registradas)) {

                    Toast.makeText(this, "Bienvenido $usuario", Toast.LENGTH_LONG).show()

                    val intent = Intent(this, Menu::class.java)
                    intent.putExtra("usuario", usuario)

                    startActivity(intent)

                    //startActivity(Intent(this, Menu::class.java))
                } else {
                    Toast.makeText(this, "Datos ingresados no registrados", Toast.LENGTH_LONG).show()
                }
            }





        }
    }


    /**
    * Función Corroborar
     * Se utiliza para recorrer la base de usuarios y contraseñas registradas con el objetivo
     * de validar que las entradas sean las correctas de lo contrario mostrará un mensaje de error
    * */
    private fun Corroborar(elemento: String, datos: List<String>): Boolean {
        for (registro in 0 until datos.size){
            if (elemento == datos.get(registro)){
                return true
            }
        }
        return false
    }
}
