package com.smx.mycommonapi.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@AllArgsConstructor
@NoArgsConstructor
@Data
public class Account {

    private Integer accountId;

    private String accountName;

    private Double accountMoney;
}
