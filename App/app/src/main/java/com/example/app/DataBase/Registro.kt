package com.example.app.DataBase


import android.content.ContentValues
import java.time.LocalDateTime
import java.time.LocalTime
import kotlin.properties.Delegates


class Registro(var idUsuario: Int, var nombreUsuario: String, var nombreDispositivo: String,
               var tipoDispotivo: String,  var marcaDispositivo: String,  var serieDispositivo: Int,
               var descripcionDispsitivo: String){

    var idRegistro by Delegates.notNull<Int>()

    fun toContentValues(): ContentValues?{
        val values = ContentValues()
        values.put(RegistroDB.RegistroEntrada.ID_USUARIO, idUsuario)
        values.put(RegistroDB.RegistroEntrada.USUARIO, nombreUsuario)
        values.put(RegistroDB.RegistroEntrada.DISPOSITIVO, nombreDispositivo)
        values.put(RegistroDB.RegistroEntrada.TIPO, tipoDispotivo)
        values.put(RegistroDB.RegistroEntrada.MARCA, marcaDispositivo)
        values.put(RegistroDB.RegistroEntrada.SERIE, serieDispositivo)
        values.put(RegistroDB.RegistroEntrada.DESCRIPCION, descripcionDispsitivo)
        return  values
    }

}