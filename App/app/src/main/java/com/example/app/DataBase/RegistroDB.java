package com.example.app.DataBase;

import android.provider.BaseColumns;

class RegistroDB
    {
        /**
         * Estructura de la tabla para almacenar toda la información solicitada
         * */
        public static abstract class RegistroEntrada implements BaseColumns{
            //Nombre de la tabla
            public static final String TABLE_NAME = "Registros";

            //Columnas de la tabla

            //Relacionado al usuario
            public static final String ID_USUARIO = "idUsuario";
            public static final String USUARIO = "nombreUsuario";

            //Relacionado al dispositivo
            public static final String DISPOSITIVO = "nombreDispositivo";
            //public static final String TIPO = "tipoDispositivo";
            public static final String MARCA = "marcaDispositivo";
            public static final String SERIE = "serieDispositivo";
            //public static final String DESCRIPCION = "descripcionDispositivo";
        }
    }

