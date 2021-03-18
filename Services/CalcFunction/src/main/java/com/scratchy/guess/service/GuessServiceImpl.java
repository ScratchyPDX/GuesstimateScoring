package com.scratchy.guess.service;

import com.scratchy.guess.model.Guess;
import java.util.ArrayList;

public class GuessServiceImpl implements GuessService{
    @Override
    public Integer getGuessVarianceValue(Integer guessValue, Integer actualValue) {
        return getGuessDifferenceFromActualValue(actualValue, guessValue);
    }

    @Override
    public ArrayList<Guess> updateAllGuessesWithVarianceValue(ArrayList<Guess> guesses, int actualValue) {
        ArrayList<Guess> updatedGuesses = new ArrayList<>();
        for (Guess guess: guesses) {
            int difference = getGuessDifferenceFromActualValue(actualValue, guess.getGuessValue());
            Guess newGuess = updateGuessWithVarianceValue(guess, difference);
            updatedGuesses.add(newGuess);
        }
        return updatedGuesses;
    }

    int getGuessDifferenceFromActualValue(int actualValue, int guessValue) {
        return Math.abs(guessValue - actualValue);
    }

    Guess updateGuessWithVarianceValue(Guess guess, int difference) {
        Guess guessObj = new Guess();
        guessObj.setPlayerId(guess.getPlayerId());
        guessObj.setGuessValue(guess.getGuessValue());
        guessObj.setOverUnderValue(difference);
        return guessObj;
    }
}
