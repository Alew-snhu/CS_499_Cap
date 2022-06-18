package animalmonitoringsystem;

import java.util.Scanner;

public class AnimalMonitoringSystem {

    public static void main(String[] args) {
        //create scaner for user input. 
       Scanner scnr = new Scanner(System.in);
       //create objects for other classes 
       AnimalViewer  animalViewer = new AnimalViewer();
       
       HabitatViewer habitatViewer = new HabitatViewer();
     
    while (true){  
    //main menue options 
    System.out.println("1. Monitor an animal");
    System.out.println("2. Monitor a habitat");
    System.out.println("3. Exit");
    System.out.print("Please choose a number for your selection: ");
    int userInput = scnr.nextInt();
    System.out.println();
    
    //if else statements for user input options. 
    if(userInput == 1){       
        animalViewer.viewAnimals();
    }
    else if(userInput == 2){
        habitatViewer.viewHabitats();
    }
    else if(userInput == 3){
        return;
    }
    }
    }
}
