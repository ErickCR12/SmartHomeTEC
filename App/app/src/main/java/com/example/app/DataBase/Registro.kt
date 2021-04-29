package com.example.app.DataBase


import android.content.ContentValues
import java.time.LocalDateTime
import java.time.LocalTime
import kotlin.properties.Delegates


class Registro(var idCliente: Int, var nombreUsuario: String, var nombreDispositivo: String,
               var tipoDispotivo: String, var serieDispositivo: Int, var descripcionDispsitivo: String){

    var idRegistro by Delegates.notNull<Int>()

    fun toContentValues(): ContentValues?{
        val values = ContentValues()
        values.put(RegistroDb.RegistroEntrada.ID_USUARIO, idCliente)
        values.put(RegistroDb.RegistroEntrada.USUARIO, nombreUsuario)
        values.put(RegistroDb.RegistroEntrada.DISPOSITIVO, nombreDispositivo)
        values.put(RegistroDb.RegistroEntrada.DISPOSITIVO, tipoDispotivo)
        values.put(RegistroDb.RegistroEntrada.MARCA, marcaDispositivo)
        values.put(RegistroDb.RegistroEntrada.SERIE, serieDispositivo)
        values.put(RegistroDb.RegistroEntrada.DESCRIPCION, descripcionDispsitivo)
        return  values
    }

}