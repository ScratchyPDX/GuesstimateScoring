package com.scratchypdx.guesstimate.scoreround.model;

import com.sun.istack.NotNull;
import com.sun.istack.Nullable;
import io.swagger.annotations.ApiModelProperty;
import org.springframework.beans.factory.annotation.Value;

public class Player {
    @Nullable
    @ApiModelProperty("Auto-populated in DB")
    private int id;

    @NotNull
    private String name;

    @Nullable
    @ApiModelProperty("Optional calculated value")
    private int score;

    public Player() {}

    public Player(int id, String name, int score) {
        setId(id);
        setName(name);
        setScore(score);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }
}
