package com.scratchypdx.guesstimate.calculatevariance.service;

import com.scratchypdx.guesstimate.calculatevariance.model.Guess;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class CalculateServiceImpl implements CalculateService {

    @Override
    public Integer calculateVariance(Integer guessValue, Integer actualValue) {
        Integer difference = Math.abs(guessValue - actualValue);
        System.out.println("calculateVariance: difference=" + difference);
        return difference;
    }

    @Override
    public ArrayList<Guess> calculateVariances(ArrayList<Guess> guesses, int actualValue) {
        ArrayList<Guess> updateGuesses = new ArrayList<>();
        System.out.println("calculateVariance: before loop");
        for (int index = 0; index < guesses.size(); index++) {
            Guess guess = new Guess();
            int difference = Math.abs(guesses.get(index).getGuessValue() - actualValue);
            guess.setPlayerId(guesses.get(index).getPlayerId());
            guess.setGuessValue(guesses.get(index).getGuessValue());
            guess.setOverUnderValue(difference);
            System.out.println("calculateVariance: guess");
            System.out.println("calculateVariance: PlayerId=" + guess.getPlayerId());
            System.out.println("calculateVariance: Value=" + guess.getGuessValue());
            System.out.println("calculateVariance: Variance=" + guess.getOverUnderValue());
            updateGuesses.add(guess);
        }
        System.out.println("calculateVariance: before return");
        System.out.println("calculateVariance: updatedGuesses size=" + updateGuesses.size());
        return updateGuesses;
    }
}
