package com.example.app.DataBase

import android.provider.BaseColumns

class RegistroDb {
        /**
         * Estructura de la tabla para almacenar toda la información solicitada
         */
        object RegistroEntrada : BaseColumns {
            const val TABLE_NAME = "registro_usuario"
            const val ID_USUARIO = "idUsuario"
            const val USUARIO = "nombreUsuario"
            const val DISPOSITIVO = "nombreDispositivo"
            const val MARCA = "marcaDispositivo"
            const val SERIE = "serieDispositivo"
            const val DESCRIPCION = "descripcionDispositivo"
        }
}


