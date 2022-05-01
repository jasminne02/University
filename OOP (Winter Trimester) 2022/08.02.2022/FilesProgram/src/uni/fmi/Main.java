package uni.fmi;

import java.io.*;
import java.util.Locale;
import java.util.Scanner;
import javax.speech.AudioException;
import javax.speech.Central;
import javax.speech.EngineException;
import javax.speech.synthesis.Synthesizer;
import javax.speech.synthesis.SynthesizerModeDesc;

public class Main {
    static Scanner input = new Scanner(System.in);

    public static void main(String[] args) throws IOException, AudioException, EngineException, InterruptedException {
        int commandMain;

        do {
            System.out.print("Options:\n1-Write in text file 2-Read a file 0-Exit\nYour choice: ");
            commandMain = input.nextInt();

            switch (commandMain){
                case 1:
                    writeInFile();
                    break;
                case 2:
                    readAFile();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Invalid option!");
            }

        } while (commandMain != 0);

    }

    public static void writeInFile() throws IOException {
        FileWriter fileWriter = new FileWriter("text.rtf");
        String command;

        System.out.print("Type \"Stop writing\" on a new line to end your writing.\nYour message: ");

        do {
            command = input.nextLine();
            if (command.equals("Stop writing")) break;

            fileWriter.write(command + "\n");
        } while (true);
        fileWriter.close();
    }

    public static void readAFile() throws EngineException, AudioException, InterruptedException, IOException {
        String fileName = "text.rtf";
        String changeFileName;

        System.out.print("Do you want to read \"text.rtf\" file?");
        changeFileName = input.nextLine().toLowerCase(Locale.ROOT);
        if (changeFileName.equals("yes")){
            fileName = input.nextLine();
        }

        FileReader reader = new FileReader(fileName);
        String fileToStr = "";

        System.setProperty("freetts.voices", "com.sun.speech.freetts.en.us" + ".cmu_us_kal.KevinVoiceDirectory");
        Central.registerEngineCentral("com.sun.speech.freetts" + ".jsapi.FreeTTSEngineCentral");
        Synthesizer synthesizer = Central.createSynthesizer(new SynthesizerModeDesc(Locale.US));
        synthesizer.allocate();
        synthesizer.resume();

        int data = reader.read();
        while (data != -1){
            System.out.print((char)data);
            fileToStr += (char)data;
            data = reader.read();
        }
        reader.close();

        synthesizer.speakPlainText(fileToStr, null);
        synthesizer.waitEngineState(Synthesizer.QUEUE_EMPTY);
        synthesizer.deallocate();
    }
}
