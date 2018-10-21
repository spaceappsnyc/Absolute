package dev.edmt.androidcamerarecognitiontext;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Handler;
import android.os.SystemClock;
import android.speech.tts.TextToSpeech;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.util.Locale;
import java.util.Set;
import java.util.UUID;

public class Main2Activity extends AppCompatActivity {
TextView tw;
Button btn;
    Button btn4;
    Button btn2;
public static String s="hello";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        tw=(TextView)findViewById(R.id.textView2);
        btn=(Button)findViewById(R.id.button2);

        btn2=(Button)findViewById(R.id.button3);
        btn4=(Button)findViewById(R.id.button4);

        tts=new TextToSpeech(Main2Activity.this, new TextToSpeech.OnInitListener() {

            @Override
            public void onInit(int status) {
                // TODO Auto-generated method stub
                if(status == TextToSpeech.SUCCESS){
                    int result=tts.setLanguage(Locale.US);
                    if(result==TextToSpeech.LANG_MISSING_DATA ||
                            result==TextToSpeech.LANG_NOT_SUPPORTED){

                    }
                    else{
                        ConvertTextToSpeech();
                    }
                }


            }
        });


        View.OnClickListener oclBtnOk = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                tts.stop();
                tts.shutdown();
                startActivity(new Intent(getApplicationContext(), MainActivity.class));

            }
        };
        View.OnClickListener oclBtnOk4 = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                tts.stop();
                tts.shutdown();
                startActivity(new Intent(getApplicationContext(), Main3Activity.class));

            }
        };
        View.OnClickListener oclBtnOk2 = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                tts=new TextToSpeech(Main2Activity.this, new TextToSpeech.OnInitListener() {

                    @Override
                    public void onInit(int status) {
                        // TODO Auto-generated method stub
                        if(status == TextToSpeech.SUCCESS){
                            int result=tts.setLanguage(Locale.US);
                            if(result==TextToSpeech.LANG_MISSING_DATA ||
                                    result==TextToSpeech.LANG_NOT_SUPPORTED){

                            }
                            else{
                                ConvertTextToSpeech();
                            }
                        }


                    }
                });
                tts.setLanguage(Locale.US);
                tts.speak(s, TextToSpeech.QUEUE_ADD, null);
            }
        };
        btn.setOnClickListener(oclBtnOk);
        btn2.setOnClickListener(oclBtnOk2);
        btn4.setOnClickListener(oclBtnOk4);
        tw.setText(s);

    }

    private void ConvertTextToSpeech() {
        // TODO Auto-generated method stub

        if(s==null||"".equals(s))
        {

        }else
            tts.speak(s, TextToSpeech.QUEUE_FLUSH, null);
    }

    TextToSpeech tts;
    @Override
    public void onResume(){
        super.onResume();
        tts.stop();
        tw.setText(s);


    }





}
