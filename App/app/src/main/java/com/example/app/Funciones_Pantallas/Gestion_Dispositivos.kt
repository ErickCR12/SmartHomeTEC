package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.DataBase.Registro
import com.example.app.DataBase.RegistroDBHelper
import com.example.app.R
import kotlinx.android.synthetic.main.dispositivos.*


class Gestion_Dispositivos: AppCompatActivity() {

    //Se crea un list de dispositivos registrados y caracaterísticas
    val dispositivos_registrados = arrayListOf<String>()
    val tipos_registrados = arrayListOf<String>()
    val marcas_registrados = arrayListOf<String>()
    val series_registrados = arrayListOf<String>()
    val consumo_registrados = arrayListOf<String>()
    val garantias_registrados = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.dispositivos)

        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val aposentos_re = intent.getStringArrayListExtra("aposentos")
        /** FALTA UNA VARIABLE PARA RECIBIR LA GARANTÍA*/

        //Variables para recibir los datos de entrada de los dispositivos y sus características
        val disp_nombre = findViewById<EditText>(R.id.txtdispsotivo) as EditText
        val disp_tipo = findViewById<EditText>(R.id.txttipo) as EditText
        val disp_marca = findViewById<EditText>(R.id.txtmarca) as EditText
        val disp_serie = findViewById<EditText>(R.id.txtseries) as EditText
        val disp_consumo = findViewById<EditText>(R.id.txtconsumo) as EditText

        btnagregadis.setOnClickListener {

            //Se capturan los valores de los satos registrados por el usuario
            val disp_nombre_ing = disp_nombre.text.toString()
            val disp_tipo_ing = disp_tipo.text.toString()
            val disp_marca_ing = disp_marca.text.toString()
            val disp_serie_ing = disp_serie.text.toString()
            val disp_consumo_ing = disp_consumo.text.toString()

            //Se agregan a un array para su control y gestión
             dispositivos_registrados.add(disp_nombre_ing)
             tipos_registrados.add(disp_tipo_ing)
             marcas_registrados.add(disp_marca_ing)
             series_registrados.add(disp_serie_ing)
             consumo_registrados.add(disp_consumo_ing)

            //Se limpian lo espacios para la siguiente añadidura
            disp_nombre.setText("")
            disp_tipo.setText("")
            disp_marca.setText("")
            disp_serie.setText("0")
            disp_consumo.setText("")

            //Esta sección de códgio sireve para mostrar la información de fecha y hora
            val calendario:java.util.Calendar = java.util.Calendar.getInstance()

            //El formato es Día-Mes-Año la garantía
            val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
            val mes = calendario.get(java.util.Calendar.MONTH)
            val ano = calendario.get(java.util.Calendar.YEAR)

            /** AQUÍ SE TENDRÍA QUE RECIBIR EL MES DE GARANTÍA QUE VIENE DEL API PARA HACER EL CÁLCULO*/
            val garantia = mes + 1

            //BASES DE DATOS

            val baseDatos = RegistroDBHelper(this)
            deleteDatabase(RegistroDBHelper.DATABASE_NAME)
            baseDatos.crearRegistro(
                    baseDatos.readableDatabase, Registro(
                        0,
                        "Joshua",
                        disp_nombre_ing,
                        //disp_tipo_ing,
                        disp_marca_ing,
                        disp_serie_ing.toInt()
                        //disp_nombre_ing
                    )
            )
        }

        btnsiguiente.setOnClickListener {

            val intent = Intent(this, Menu::class.java)

            dispositivos_registrados.add("*")

            for (registro in 0 until aposentos_re.size) {
                dispositivos_registrados.add(aposentos_re[registro])
                }

            intent.putExtra("dispositivos", dispositivos_registrados)
            startActivity(intent)

            //intent.putExtra("aposentos", aposentos_re)
            //intent.putExtra("marcas", marcas_registrados)
            //intent.putExtra("series", series_registrados)
            //intent.putExtra("consumos", consumo_registrados)
            //intent.putExtra("tiempos", garantias_registrados)

        }
    }
}