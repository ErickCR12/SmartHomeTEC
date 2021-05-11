package com.example.app.Funciones_Pantallas

import android.annotation.SuppressLint
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.aposentos.*
import kotlinx.android.synthetic.main.dispositivos.*

class Gestion_Aposentos: AppCompatActivity() {

    //Se crea un list de aposentos registrados
    val aposentos_registrados = arrayListOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.aposentos)


        //Se recibe la información de los aposentos registrados de al ventana anterior
        val intent = getIntent()
        val usuario_re = intent.getStringExtra("usuario")


        //Variables para recibir los datos de entrada de los aposentos
        val aposento_nombre = findViewById<EditText>(R.id.txtaposentonombre) as EditText

        val editar_aposento = findViewById<EditText>(R.id.txtaposentonombre2) as EditText
        editar_aposento.visibility = View.INVISIBLE

        //Variaable para mostrar la información en un label al usuario
        val label = findViewById<TextView>(R.id.lblindicador) as TextView

        //Variable para administrar el spinner con la información de platillos
        //Se crea un spinner para mostar los platillos seleccionados por el usuario
        val aposentos_disponibles = findViewById<Spinner>(R.id.spnseleccionados)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val lista_aposentos = ArrayAdapter(this,android.R.layout.simple_spinner_item, aposentos_registrados)
        aposentos_disponibles.adapter = lista_aposentos

        var aposento: String

        //Se habilitan todos los botones
        btneditar.isEnabled = true
        btnconsulta.isEnabled = true
        btneliminar2.isEnabled = true
        btnanadir.isEnabled = true


        //Botón para añadir aposentos a la aplicación
        btnanadir.setOnClickListener {
            //Se muestra la función que se esté ejecutando en el momento
            label.setText("Añadir Aposento")
        }

        //Botón para eliminar aposentos a la aplicación
        btneliminar2.setOnClickListener {
            //Se muestra la función que se esté ejecutando en el momento
            label.setText("Eliminar Aposento")
        }

        btneditar.setOnClickListener {
            //Se muestra la función que se esté ejecutando en el momento
            label.setText("Editar Aposento")

            editar_aposento.visibility = View.VISIBLE
        }

        //Botón para consultar los aposentos de la aplicación
        btnconsulta.setOnClickListener {
            //Se muestra la función que se esté ejecutando en el momento
            label.setText("Consultar Aposento")

            aposento_nombre.visibility = View.INVISIBLE
            editar_aposento.visibility = View.INVISIBLE

            //Se habilita el spinner para mostrar la información de aposentos
            aposentos_disponibles.visibility = View.VISIBLE
        }


        /**
         * Se seleccionan las diferentes opciones de gestión de dispositivos al hacer click
         * en el botón de confirmar, las opciones disponibles para su gestión son las de
         * añadir, eliminar, editar y consultar algún aposento, cada uan de estas se almacenan
         * en una variable para su respeciva administración
         * **/
        btnconfirmar2.setOnClickListener {

            /**
             * Para añadir un nuevo aposento lo que se necesita nada mas es seleccionar el botón con
             * la leyenda "Añadir", agregar el aposento deseado y una vez hecho esto se presiona el
             * botón de "confirmar", en caso de que no se añada ningún dispositivo, se añdaen 4 por
             * default: dormitorio, cocina, sala, comedor
             * */
            if (label.text == "Añadir Aposento"){

                //Se toma el nombre del registro del aposento ingresado por el usuario
                aposento = aposento_nombre.text.toString()
                //Si no se añade ningún aposento registrado se añaden por default
                //dormitorio, cocina, sala, comedor
                if (aposento_nombre.text.toString().isNullOrEmpty()) {
                    aposentos_registrados.add("dormitorio")
                    aposentos_registrados.add("cocina")
                    aposentos_registrados.add("sala")
                    aposentos_registrados.add("comedor")
                    Log.i("infoA", aposentos_registrados.toString())
                } else {
                    //Si el usuario ingresa un aposento válido se añade a la lista vacia
                    aposentos_registrados.add(aposento)
                    aposentos_registrados.add("dormitorio")
                    aposentos_registrados.add("cocina")
                    aposentos_registrados.add("sala")
                    aposentos_registrados.add("comedor")
                    Log.i("infoA", aposentos_registrados.toString())
                }

                aposento_nombre.visibility = View.VISIBLE
                editar_aposento.visibility = View.INVISIBLE
                aposentos_disponibles.visibility = View.INVISIBLE
            }

            /**
             * Para eliminar un nuevo aposento lo que se necesita nada mas es seleccionar el botón con
             * la leyenda "Eliminar", agregar el aposento deseado y una vez hecho esto se presiona el
             * botón de "confirmar", con esto se elimina el respectivo elemento del array
             * */
            if (label.text == "Eliminar Aposento"){

                //Se toma el nombre del registro del aposento ingresado por el usuario
                aposento = aposento_nombre.text.toString()
                //Se elimina el elemento registrado por el usuario
                aposentos_registrados.remove(aposento)

                Log.i("infoE", aposentos_registrados.toString())


                aposento_nombre.visibility = View.VISIBLE
                editar_aposento.visibility = View.INVISIBLE
                aposentos_disponibles.visibility = View.INVISIBLE
            }

            /**
             * Para editar un  aposento lo que se necesita nada mas es seleccionar el botón con
             * la leyenda "Editar", agregar el aposento a editar con el nombre original y el
             * desado con el nombre nuevo en el segundo entry, presionar el botón de "confirmar" y
             * las nuevas modificaciones son registradas
             * */
            if (label.text == "Editar Aposento"){

                //Se toma el nombre del registro del aposento ingresado por el usuario
                aposento = aposento_nombre.text.toString()

                //Se busca la posición del elemento que se debe buscar
                val posicion_a_modificar = Posicion(aposento, aposentos_registrados)

                //Se elimina el elemento registrado por el usuario
                aposentos_registrados.remove(aposento)

                //Se cambia el valor deseado en la posición correspondiente
                aposentos_registrados.add(posicion_a_modificar, editar_aposento.text.toString())

                Log.i("infoEDI", aposentos_registrados.toString())

                aposento_nombre.visibility = View.VISIBLE
                editar_aposento.visibility = View.INVISIBLE
                aposentos_disponibles.visibility = View.INVISIBLE
            }

            /**
             * Para consultar la lista de aposentos solo se presiona el botón de consulta y el botón
             * de confirmar y se despliega la información de todos los aposentos almacenados previamente
             * */
            if (label.text == "Consultar Aposento"){
                Log.i("infoC", aposentos_registrados.toString())

                aposento_nombre.visibility = View.VISIBLE
                editar_aposento.visibility = View.INVISIBLE
                aposentos_disponibles.visibility = View.INVISIBLE
            }
        }

        //Se envía toda la información a la ventana de gestión de dispositivos
        btnvisualizar2.setOnClickListener {

            aposentos_registrados.add(usuario_re)

            val intent = Intent(this, Menu::class.java)
            intent.putExtra("aposentos", aposentos_registrados)
            startActivity(intent)

            //startActivity(Intent(this, Menu::class.java))
        }
    }

    private fun Posicion(elemento: String, datos: List<String>): Int {
        for (registro in 0 until datos.size) {
            if (elemento == datos.get(registro)) {
                return registro
            }
        }
        return -1
    }
}