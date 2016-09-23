package com.constrosoft.model;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ModifyHBMFile {
	public static void main(String[] args) {

		try {
			String hbmFilePath = "C:\\MyData\\Sunil\\WizEye\\ConstroSoft\\Repo\\DBUtility\\ConstroSoftUtility\\Domain";
			File f = new File(hbmFilePath);
			ModifyHBMFile modifyHBMFile = new ModifyHBMFile();
			List<String> tablesWithVersion = new ArrayList<String>();
			if (f.isDirectory()) {
				for (File file : f.listFiles()) {
					if (!file.isDirectory()) {
						modifyHBMFile.findTablesWithVersion(file, tablesWithVersion);
					}
				}
				for (File file : f.listFiles()) {
					if (!file.isDirectory()) {
						modifyHBMFile.modify(file, tablesWithVersion);
					}
				}
				System.out.println("Process Completed.....");
			} else {
				System.out.println("Directory Does not exist.");
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void modify(File hbmFile, List<String> tablesWithVersion) throws IOException {
		String newFileName = hbmFile.getName().replace("DataModel1.", "");
		newFileName = newFileName.replace("MasterControlDatum", "MasterControlData");
		String tmpFileName = "C:\\MyData\\Sunil\\WizEye\\ConstroSoft\\Repo\\DBUtility\\ConstroSoftUtility\\Domain\\Modified\\" + newFileName;
		if (!tmpFileName.endsWith("hbm.xml")) {
			formatDomainFile(hbmFile, tmpFileName);
		} else {
			formatHBMFile(hbmFile, tmpFileName, tablesWithVersion);
		}
	}

	private void findTablesWithVersion(File hbmFile, List<String> tablesWithVersion) {
		String classLineWord = "  <class name=\"";
		BufferedReader br = null;
		try {
			br = new BufferedReader(new FileReader(hbmFile));
			String line;
			String tableName = "";
			while ((line = br.readLine()) != null) {
				if (line.startsWith(classLineWord)) {
					tableName = getDBTableName(line);
				}
				if(line.contains("name=\"Version\"")) {
					tablesWithVersion.add(tableName);
					break;
				}
			}
		} catch (Exception e) {
			return;
		} finally {
			try {
				if (br != null)
					br.close();
			} catch (IOException e) {
				//
			}
		}
	}
	private String getDBTableName(String line) {
		String tableWord = "table=\"";
		String schemaWord = "schema=\"dbo\"";
		line = line.replaceAll(schemaWord, "");
		line = line.substring(line.indexOf(tableWord), line.length());
		line = line.replaceAll("\"", "");
		line = line.replaceAll(">", "");
		return line.trim();
	}
	private void formatHBMFile(File hbmFile, String tmpFileName, List<String> tablesWithVersion) {
		String classLineWord = "  <class name=\"";
		String tableWord = "\" table=";
		String schemaWord = "schema=\"dbo\"";
		String versionField = "    <version name=\"Version\" column=\"VERSION\" type=\"Int64\"/>";
		BufferedReader br = null;
		BufferedWriter bw = null;
		try {
			br = new BufferedReader(new FileReader(hbmFile));
			bw = new BufferedWriter(new FileWriter(tmpFileName));
			String line;
			int rowversionInx = 3;
			String tableName = "";
			while ((line = br.readLine()) != null) {
				if (line.startsWith("<hibernate-mapping assembly=")) {
					line = line.replaceAll("ConstroSoftNH", "ConstroSoft");
				}
				if (line.startsWith(classLineWord)) {
					//line = line.replace(tableWord, ", App_Code/Model" + tableWord);
					tableName = getDBTableName(line);
				}
				if(line.contains("</id>")) {
					bw.write(line + "\n");
					if (tablesWithVersion.contains(tableName)) bw.write(versionField + "\n");
				} else if(line.contains("name=\"Version\"") || (rowversionInx > 0 && rowversionInx < 3)) {
					rowversionInx --;
				} else {
					if (line.contains(schemaWord)) {
						line = line.replaceAll(schemaWord, "");
					}
					line = line.replace("MasterControlDatum", "MasterControlData");
					line = correctMasterDataTableKeysInHBM(line);
					bw.write(line + "\n");
				}
			}
		} catch (Exception e) {
			return;
		} finally {
			try {
				if (br != null)
					br.close();
			} catch (IOException e) {
				//
			}
			try {
				if (bw != null)
					bw.close();
			} catch (IOException e) {
				//
			}
		}
	}
	private void formatDomainFile(File domainFile, String tmpFileName) {
		BufferedReader br = null;
		BufferedWriter bw = null;
		try {
			br = new BufferedReader(new FileReader(domainFile));
			bw = new BufferedWriter(new FileWriter(tmpFileName));
			String line;
			while ((line = br.readLine()) != null) {
				line = line.replace("MasterControlDatum", "MasterControlData");
				if(line.contains("ConstroSoftNH")) {
					line = line.replace("ConstroSoftNH","ConstroSoft");
				}
				line = correctMasterDataTableKeysInDomain(line);
				bw.write(line + "\n");
			}
		} catch (Exception e) {
			return;
		} finally {
			try {
				if (br != null)
					br.close();
			} catch (IOException e) {
				//
			}
			try {
				if (bw != null)
					bw.close();
			} catch (IOException e) {
				//
			}
		}
	}
	private String correctMasterDataTableKeysInDomain(String line) {
		String result = line;
		String wordToFind = "public virtual MasterControlData MasterControlData_";
		if(result.contains(wordToFind)) {
			String fieldName = result.replaceFirst(wordToFind, "");
			result = result.replace("MasterControlData_", "");
			fieldName = fieldName.trim();
			String newFieldName = getMCDFKName(fieldName);
			result = result.replace(fieldName, newFieldName);
		}
		
		return result;
	}
	private String correctMasterDataTableKeysInHBM(String line) {
		String result = line;
		String wordToFind = "<many-to-one name=\"MasterControlData_";
		if(result.contains(wordToFind)) {
			String fieldName = result.replaceFirst(wordToFind, "");
			result = result.replace("MasterControlData_", "");
			fieldName = (fieldName.substring(0, fieldName.indexOf("\""))).trim();
			String newFieldName = getMCDFKName(fieldName);
			result = result.replace(fieldName, newFieldName);
		}
		
		return result;
	}
	private String getMCDFKName(String orgName) {
		String tmpName = orgName;
		StringBuilder newName = new StringBuilder();
		int index = 0;
		for (char c : tmpName.toCharArray()) {
			if(index == 0) {
				newName.append(Character.toUpperCase(c));
				index++;
			}else if (c == '_') {
	        	index = 0;
	        } else {
	        	newName.append(Character.toLowerCase(c));
	        }
		}
		return newName.toString();
	}
}