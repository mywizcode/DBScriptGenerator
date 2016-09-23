package com.constrosoft.model;

import java.io.File;
import java.io.FileInputStream;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class CitySQL {

	public static void main(String[] args) {
		try {
			File sourceFile = new File("C:\\MyData\\Sunil\\WizEye\\ConstroSoft\\DB\\State_City.xlsx");
			FileInputStream file = new FileInputStream(sourceFile);

			// Create Workbook instance holding reference to .xlsx file
			XSSFWorkbook workbook = new XSSFWorkbook(file);
			// Get first/desired sheet from the workbook
			StringBuffer dbScript = new StringBuffer();
			dbScript.append("INSERT INTO COUNTRY (NAME,ABBREVIATION) VALUES ('India', 'IND');");
			dbScript.append("\n");
			Map<Integer, State> stateMap = new HashMap<Integer, State>();
			XSSFSheet sheet = workbook.getSheetAt(0);
			// Iterate through each rows one by one
			Iterator<Row> rowIterator = sheet.iterator();
			rowIterator.next();
			while (rowIterator.hasNext()) {
				Row row = rowIterator.next();
				Integer id = (new Double(row.getCell(0).getStringCellValue())).intValue();
				State state = new State();
				state.setId(id);
				state.setName(row.getCell(1).getStringCellValue());
				state.setAbbr(row.getCell(2).getStringCellValue());
				stateMap.put(id, state);
				dbScript.append("INSERT INTO STATE (NAME,ABBREVIATION,COUNTRY_ID) SELECT '"+state.getName()+"','"+state.getAbbr()+"',ID FROM COUNTRY WHERE NAME = 'India';");
				dbScript.append("\n");
			}
			XSSFSheet sheet1 = workbook.getSheetAt(1);
			// Iterate through each rows one by one
			Iterator<Row> rowIterator1 = sheet1.iterator();
			rowIterator1.next();
			while (rowIterator1.hasNext()) {
				Row row = rowIterator1.next();
				Integer id = (new Double(row.getCell(0).getNumericCellValue()+"")).intValue();
				City city = new City();
				city.setId(id);
				city.setName(row.getCell(1).getStringCellValue());
				Integer stateId = (new Double(row.getCell(2).getNumericCellValue()+"")).intValue();
				State state = stateMap.get(stateId);
				dbScript.append("INSERT INTO CITY (NAME,ABBREVIATION,STATE_ID) SELECT '"+city.getName()+"','',ID FROM STATE WHERE NAME = '"+state.getName()+"';");
				dbScript.append("\n");
			}
			System.out.println(dbScript.toString());
			file.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	private static void createCitySQL() {
		
	}
	
}
class City{
	private Integer id;
	private String name;
	private Integer stateId;
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Integer getStateId() {
		return stateId;
	}
	public void setStateId(Integer stateId) {
		this.stateId = stateId;
	}
}
class State{
	private Integer id;
	private String name;
	private String abbr;
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getAbbr() {
		return abbr;
	}
	public void setAbbr(String abbr) {
		this.abbr = abbr;
	}
}
