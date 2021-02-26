package com.scratchy.guess.service;

import com.scratchy.guess.model.Guess;

import java.util.ArrayList;

public interface GuessService {
    public Integer getGuessVarianceValue(Integer guessValue, Integer actualValue);
    public ArrayList<Guess> updateAllGuessesWithVarianceValue(ArrayList<Guess> guesses, int actualValue);
}
