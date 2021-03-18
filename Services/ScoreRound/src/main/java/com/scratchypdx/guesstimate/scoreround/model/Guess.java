package com.scratchypdx.guesstimate.scoreround.model;

import com.sun.istack.NotNull;
import io.swagger.annotations.ApiModelProperty;
import org.springframework.data.annotation.ReadOnlyProperty;

public class Guess {

    @NotNull
    @ReadOnlyProperty
    @ApiModelProperty("Auto-populated in DB")
    private int playerId;
    @NotNull
    private int guessValue;
    @NotNull
    @ApiModelProperty("Optional calculated value")
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
