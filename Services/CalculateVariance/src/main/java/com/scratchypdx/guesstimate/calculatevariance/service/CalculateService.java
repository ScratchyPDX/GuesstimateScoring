package com.scratchypdx.guesstimate.calculatevariance.service;

import com.scratchypdx.guesstimate.calculatevariance.model.Guess;

import java.util.ArrayList;
import java.util.List;

public interface CalculateService {

    public Integer calculateVariance(Integer guessValue, Integer actualValue);
    public ArrayList<Guess> calculateVariances(ArrayList<Guess> guesses, int actualValue);
}
