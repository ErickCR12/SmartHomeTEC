package com.example.app.DataBase;


import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Build;
import android.util.Log;

import androidx.annotation.RequiresApi;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;


public class RegistroDBHelper extends  SQLiteOpenHelper{

    public static final int DATABASE_VERSION =1;
    public static final String DATABASE_NAME = "Resgistros.db";

    @Override
    public SQLiteDatabase getReadableDatabase(){
        return  super.getReadableDatabase();
    }

    public RegistroDBHelper(Context context){
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL("CREATE TABLE IF NOT EXISTS " + RegistroDB.RegistroEntrada.TABLE_NAME + "("
                + RegistroDB.RegistroEntrada.ID_USUARIO + "INTEGER PRIMARY KEY AUTOINCREMENT,"
                + RegistroDB.RegistroEntrada.USUARIO + "TEXT NOT NULL,"
                + RegistroDB.RegistroEntrada.DISPOSITIVO + "TEXT NOT NULL,"
                + RegistroDB.RegistroEntrada.MARCA + "TEXT NOT NULL,"
                + RegistroDB.RegistroEntrada.SERIE + "INTEGER NOT NULL,"
                + RegistroDB.RegistroEntrada.DESCRIPCION + "TEXT,"
                + "UNIQUE (" + RegistroDB.RegistroEntrada.SERIE + "))"
        );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
    }

    public void  crearRegistro(SQLiteDatabase db, Registro registro){
        db.insert(
                RegistroDB.RegistroEntrada.TABLE_NAME,
                null,
                registro.toContentValues());
        Cursor cursor = getReadableDatabase().rawQuery("select last_insert_rowid() as idUsuario from registro", null );
        if(cursor.moveToFirst()){
            do{
                Integer id = cursor.getInt(cursor.getColumnIndex("idUsuario"));
                Log.e("ID", id.toString());
                registro.setIdRegistro(id);
            }while (cursor.moveToNext());
        }
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    public List<Registro> getListaRegistro(Integer id){
        List<Registro> lista = new ArrayList<Registro>();
        Cursor cursor = getReadableDatabase()
                .rawQuery("SELECT * FROM registro WHERE idUsuario == ?", new String[]{id.toString()});
        if (cursor.moveToFirst()){
            do{
                Registro registro = new Registro(cursor.getInt(cursor.getColumnIndex("idUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreDispositivo")),
                        cursor.getString(cursor.getColumnIndex("tipoDispositivo")),
                        cursor.getString(cursor.getColumnIndex("marcaDispositivo")),
                        cursor.getInt(cursor.getColumnIndex("serieDispositivo")),
                        cursor.getString(cursor.getColumnIndex("descripcionDispositivo"))
                        /**REVISAR EL DETALLE DE AQUÍ**/
                        );
                //Corregir este detalle
                registro.setIdUsuario(cursor.getColumnIndex("idUsuario"));
                lista.add(registro);
            }while (cursor.moveToNext());
        }
        return lista;
    }

    public int updateActividad(Registro registro, Integer idRegistro){
        return getWritableDatabase().update(
                RegistroDB.RegistroEntrada.TABLE_NAME,
                registro.toContentValues(),
                RegistroDB.RegistroEntrada.ID_USUARIO + "LIKE ?",
                new String[]{idRegistro.toString()}
        );
    }

}
