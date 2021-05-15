package com.example.app.DataBase


import android.content.ContentValues
import java.time.LocalDateTime
import java.time.LocalTime
import kotlin.properties.Delegates


class Registro(var idUsuario: Int, var nombreUsuario: String, var nombreDispositivo: String,
               var marcaDispositivo: String,  var serieDispositivo: Int){

    fun toContentValues(): ContentValues?{
        val values = ContentValues()
        //Valores relacionados al usuario
        values.put(RegistroDB.RegistroEntrada.ID_USUARIO, idUsuario)
        values.put(RegistroDB.RegistroEntrada.USUARIO, nombreUsuario)
        //Valores relacionados al dispositivos
        values.put(RegistroDB.RegistroEntrada.DISPOSITIVO, nombreDispositivo)
        values.put(RegistroDB.RegistroEntrada.MARCA, marcaDispositivo)
        values.put(RegistroDB.RegistroEntrada.SERIE, serieDispositivo)
        return  values
    }

}