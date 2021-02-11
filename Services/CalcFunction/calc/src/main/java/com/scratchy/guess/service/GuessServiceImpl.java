package com.scratchy.guess.service;

import com.scratchy.guess.model.Guess;
import java.util.ArrayList;

public class GuessServiceImpl implements GuessService{
    @Override
    public Integer calculateVariance(Integer guessValue, Integer actualValue) {
        Integer difference = Math.abs(guessValue - actualValue);
        //System.out.println("calculateVariance: difference=" + difference);
        return difference;
    }

    @Override
    public ArrayList<Guess> calculateVariances(ArrayList<Guess> guesses, int actualValue) {
//        ObjectMapper objectMapper = new ObjectMapper();
//        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Guess>>(){});
//        ArrayList<Guess> guessesArrayList = objectReader.readValue(guesses);

        ArrayList<Guess> updatedGuesses = new ArrayList<>();

        for (int index = 0; index < guesses.size(); index++) {
            Guess guess = new Guess();
            int difference = Math.abs(guesses.get(index).getGuessValue() - actualValue);
            guess.setPlayerId(guesses.get(index).getPlayerId());
            guess.setGuessValue(guesses.get(index).getGuessValue());
            guess.setOverUnderValue(difference);
            updatedGuesses.add(guess);
        }
        return updatedGuesses;
    }
}
