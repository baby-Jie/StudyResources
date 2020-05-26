package com.smx.springintergrations.poi;

import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.junit.Test;

public class PoiTest1 {

    @Test
    public void test1(){

        //创建工作簿 类似于创建Excel文件
        XSSFWorkbook workbook = new XSSFWorkbook();

        XSSFSheet sheet = workbook.createSheet("员工信息");
        sheet.setColumnWidth(3, 20 * 256); //给第3列设置为20个字的宽度
    }
}
