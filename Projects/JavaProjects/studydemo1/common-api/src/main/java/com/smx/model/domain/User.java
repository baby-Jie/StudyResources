package com.smx.model.domain;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Column;
import javax.persistence.Id;
import javax.persistence.Table;
import java.io.Serializable;
import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Table
public class User implements Cloneable, Serializable {

    @Id
    private Long id;
    @Column(name = "username")
    private String userName;
    private String sex;
    private String address;
    private List<String> addressList;

    public User clone() {
        User clone = null;
        try {
            clone = (User) super.clone();
        } catch (Exception e) {

        } finally {
        }
        return clone;
    }
}
