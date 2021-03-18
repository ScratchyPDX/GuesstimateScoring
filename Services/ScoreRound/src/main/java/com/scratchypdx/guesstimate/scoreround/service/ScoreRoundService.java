package com.scratchypdx.guesstimate.scoreround.service;

import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;

import java.util.ArrayList;

public interface ScoreRoundService {

    public Player getPlayer(int id);
    public ArrayList<Player> getPlayers();
    public Player addPlayer(String playerNme);
    public Player addPlayer(Player player);
    public void deletePlayer(Integer id);
    public void deleteAllPlayers();
    public ArrayList<Player> scoreRound(ArrayList<Guess> Guesses);
}
