package com.scratchypdx.guesstimate.scoreround.model;

public class Guess {

    private int playerId;
    private int guessValue;
    private int overUnderValue;

    public int getPlayerId() {
        return playerId;
    }

    public void setPlayerId(int playerId) {
        this.playerId = playerId;
    }

    public int getGuessValue() {
        return guessValue;
    }

    public void setGuessValue(int guessValue) {
        this.guessValue = guessValue;
    }

    public int getOverUnderValue() {
        return overUnderValue;
    }

    public void setOverUnderValue(int overUnderValue) {
        this.overUnderValue = overUnderValue;
    }
}
