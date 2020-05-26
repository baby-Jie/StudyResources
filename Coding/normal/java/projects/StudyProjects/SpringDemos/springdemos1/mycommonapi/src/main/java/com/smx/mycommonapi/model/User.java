package com.smx.mycommonapi.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.ToString;

@AllArgsConstructor
@NoArgsConstructor
@Data
@ToString
public class User implements Comparable<User> {

    private Integer userId;

    private String userName;

    private Integer score;

    @Override
    public int compareTo(User o) {
        return this.score - o.getScore();
    }
}
