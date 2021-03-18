package com.scratchypdx.guesstimate.calculatevariance.service;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectReader;
import com.scratchypdx.guesstimate.calculatevariance.model.Guess;
import org.springframework.stereotype.Service;
import com.fasterxml.jackson.core.JsonProcessingException;
import java.util.ArrayList;

@Service
public class CalculateServiceImpl implements CalculateService {

    @Override
    public Integer calculateVariance(Integer guessValue, Integer actualValue) {
        Integer difference = Math.abs(guessValue - actualValue);
        System.out.println("calculateVariance: difference=" + difference);
        return difference;
    }

    @Override
    public ArrayList<Guess> calculateVariances(String guesses, int actualValue) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Guess>>(){});
        ArrayList<Guess> guessesArrayList = objectReader.readValue(guesses);

        ArrayList<Guess> updatedGuesses = new ArrayList<>();

        for (int index = 0; index < guessesArrayList.size(); index++) {
            Guess guess = new Guess();
            int difference = Math.abs(guessesArrayList.get(index).getGuessValue() - actualValue);
            guess.setPlayerId(guessesArrayList.get(index).getPlayerId());
            guess.setGuessValue(guessesArrayList.get(index).getGuessValue());
            guess.setOverUnderValue(difference);
            updatedGuesses.add(guess);
        }
        return updatedGuesses;
    }
}
