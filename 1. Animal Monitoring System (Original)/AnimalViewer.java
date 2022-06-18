package animalmonitoringsystem;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Scanner;

public class AnimalViewer {
//handle file not found exception
    private Scanner getFileScanner() {
        try {
            FileInputStream fileByteStream = new FileInputStream("Animals");
            Scanner inFS = new Scanner(fileByteStream);
            return inFS;
        } catch (FileNotFoundException Ex) {
            System.out.println("Can not find animals file.");
            return null;
        }

    }
// hashmap created to print animal options and return number options to keywords
    private HashMap<String, String> processOptions(Scanner inFS) {
        int curOption = 1;
        String curLine = inFS.nextLine();
        
        HashMap<String, String> animalSelectMap = new HashMap<String, String>();
//while loop to print item and key options.
        while (!curLine.trim().equals("")) {
            System.out.println(curOption + "." + curLine);
            int lastSpaceIndex = curLine.lastIndexOf(" ");
            String animalType = curLine.substring(lastSpaceIndex);
            animalType = animalType.substring(0, animalType.length() - 1);
            String optionAsString = String.valueOf(curOption);
            animalSelectMap.put(optionAsString, animalType.trim());          
            curLine = inFS.nextLine();
            curOption++;
        }
        
        return animalSelectMap;
    }
    // read through file. print animal lines until empty line
    private void printAnimal(Scanner inFS) {
       String curLine = inFS.nextLine();

        while (!"".equals(curLine)) {
            // if current line contains ***** print warning to alert zookeeper.
            if (curLine.startsWith("*****")) {
                System.out.println("Warning: " + curLine.substring(5));
            } else {
                System.out.println(curLine);
            }

            if (inFS.hasNextLine()) {
                curLine = inFS.nextLine();
            } else {
                curLine = "";
            }

        }
        System.out.println();
    }
    
    public void viewAnimals() {

        Scanner inFS = getFileScanner();

        HashMap<String, String> animalSelectMap = processOptions(inFS);
        //menue options to view animals 
        System.out.print("Please enter a number: ");
        String userInput = "";
        Scanner scnr = new Scanner(System.in);
        userInput = scnr.nextLine();
        System.out.println();

        if (!animalSelectMap.containsKey(userInput.trim())) {
            System.out.println("Invalid selection.");
            return;
        }

        String animalType = animalSelectMap.get(userInput.trim());

        while (inFS.hasNextLine()) {
            String curLine = inFS.nextLine();

            String animalString = "animal - " + animalType;
            if (!animalString.equals(curLine.toLowerCase().trim())) {
                continue;
            }
            
            printAnimal(inFS);

        }

    }
}