package com.smx.springintergrations.model.entity.domain;

import lombok.Data;

import javax.persistence.*;
import java.io.Serializable;
import java.text.MessageFormat;

/**
 * 此方法没有使用mapper.xml依然能使用
 */
@Data
@Table(name = "account")
public class Account implements Serializable {

    @Id
    private Integer accountId;

    @Column(name = "account_name")
    private String accountName;

    @Column(name = "account_money")
    private float accountMoney;

    @Override
    public String toString(){
        return MessageFormat.format("accountId:{0}, accountName:{1}, accountMoney:{2}", accountId, accountName, accountMoney);
    }
}
