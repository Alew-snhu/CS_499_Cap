package animalmonitoringsystem;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Scanner;

public class HabitatViewer {
    //handle file not found exception 
    private Scanner getFileScanner() {
        try {
            FileInputStream fileByteStream = new FileInputStream("Habitats");
            Scanner inFS = new Scanner(fileByteStream);
            return inFS;
        } catch (FileNotFoundException Ex) {
            System.out.println("Can not find animals file.");
            return null;
        }

    }
    //hashmap created to print habitat options and return numbered options to keywords.
    private HashMap<String, String> processOptions(Scanner inFS) {
        int curOption = 1;
        String curLine = inFS.nextLine();
        
        HashMap<String, String> habitatSelectMap = new HashMap<String, String>();
        //while loop options to print items and key options. 
        while (!curLine.trim().equals("")) {
            System.out.println(curOption + "." + curLine);
            int lastSpaceIndex = curLine.lastIndexOf("on ") + 3;
            String stringAfterOn = curLine.substring(lastSpaceIndex);
            String[] habitatTokens = stringAfterOn.split(" ");
            String habitatlType = habitatTokens[0];
            String optionAsString = String.valueOf(curOption);
            habitatSelectMap.put(optionAsString, habitatlType.trim());          
            curLine = inFS.nextLine();
            curOption++;
        }
        
        return habitatSelectMap;
    }
    // read through file print. print animal lines until empty line.
    private void printHabitat(Scanner inFS) {
        String curLine = inFS.nextLine();
        
         while (!"".equals(curLine)) {
                // if current line contains ***** print warning to alert zookeeper.
                if (curLine.startsWith("*****")) {
                    System.out.println("Warning: " + curLine.substring(5));
                } else {
                    System.out.println(curLine);
                }
                if(inFS.hasNextLine())
                    curLine = inFS.nextLine();
                else
                    curLine = "";

            }
            System.out.println();
        
        
        
        
    }

    public void viewHabitats() {

        Scanner inFS = getFileScanner();
        

       HashMap<String, String> habitatSelectMap = processOptions(inFS);
        //menue options for viewing habitats.
        System.out.print("Please enter a number: ");
        String userInput = "";
        Scanner scnr = new Scanner(System.in);
        userInput = scnr.nextLine();
        System.out.println();

        if (!habitatSelectMap.containsKey(userInput.trim())) {
            System.out.println("Invalid selection.");
            return;
        }
        String habitatType = habitatSelectMap.get(userInput.trim());
        while (inFS.hasNextLine()) {
            String curLine = inFS.nextLine();

            String animalString = "habitat - " + habitatType;
            if (!animalString.equals(curLine.toLowerCase().trim())) {
                continue;
            }
            
            printHabitat(inFS);
            

           

        }
    }
}
