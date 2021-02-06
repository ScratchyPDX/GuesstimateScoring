package com.scratchypdx.guesstimate.scoreround.util;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectReader;
import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;

import java.util.ArrayList;
import java.util.Collections;

public class HelperUtils {

    public static Player buildPlayerFromJsonString(String playerString) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Player>>(){});
        return objectReader.readValue(playerString);
    }

    public static ArrayList<Player> buildPlayersFromJsonString(String playersString) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Player>>(){});
        return objectReader.readValue(playersString);
    }

    public static ArrayList<Guess> buildGuessesFromJsonString(String guessesString) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Guess>>(){});
        return objectReader.readValue(guessesString);
    }
}
