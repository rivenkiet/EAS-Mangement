CREATE OR REPLACE PROCEDURE Sp_Grant_Permission_To_User_Or_Role (
    permission_type IN VARCHAR2,
    tablename IN VARCHAR2,
    target_name IN VARCHAR2,
    is_grant_option IN NUMBER,
    column_name_select IN VARCHAR2,--CHUOI CAC COLUMN DUOC NGAN CACH BOI DAU PHAY
    column_name_update IN VARCHAR2
)
AS
    STRSQL VARCHAR(2000);
    STRSQL2 VARCHAR(2000);
BEGIN
    --NEU CHO PHEP SELECT TREN CAC COT CU THE
    IF column_name_select IS NOT NULL AND permission_type LIKE '%SELECT%' THEN
        STRSQL2 := '
        CREATE OR REPLACE VIEW VIEW_SELECT_COLUMN_' || tablename || '_' || target_name ||
        ' AS
        SELECT ' || column_name_select || ' 
        FROM ' || tablename || '
        WITH CHECK OPTION ';
        EXECUTE IMMEDIATE(STRSQL2);
        STRSQL := 'GRANT SELECT ON VIEW_SELECT_COLUMN_' || tablename || '_' || target_name || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';   
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    --NEU CHO PHEP UPDATE TREN TAT CA CAC COT
    ELSIF permission_type LIKE '%SELECT%' THEN
        STRSQL := 'GRANT SELECT ' || ' ON ' || tablename || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    END IF;
    --NEU CHO PHEP UPDATE TREN CAC COT CHI DINH
    IF column_name_update IS NOT NULL AND permission_type LIKE '%UPDATE%' THEN
        STRSQL := 'GRANT UPDATE (' || column_name_update || ') ON ' || tablename || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    --NEU CHO PHEP UPDATE TREN TAT CA CAC COT
    ELSIF permission_type LIKE '%UPDATE%' THEN
        STRSQL := 'GRANT UPDATE ' || ' ON ' || tablename || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    END IF;
    --NEU CHO PHEP INSERT
    IF  permission_type LIKE '%INSERT%' THEN
        STRSQL := 'GRANT INSERT' || ' ON ' || tablename || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    END IF;
    --NEU CHO PHEP DELETE
    IF permission_type LIKE '%DELETE%' THEN
        STRSQL := 'GRANT DELETE' || ' ON ' || tablename || ' TO ' || target_name;
        IF is_grant_option = 1 THEN
            STRSQL := STRSQL || ' WITH GRANT OPTION ';
        END IF;
        EXECUTE IMMEDIATE(STRSQL);
    END IF;
END;
/


--STORED PROCEDURE THUC HIEN CAP ROLE CHO USER
CREATE OR REPLACE PROCEDURE Sp_Grant_Role_To_User (
    username IN VARCHAR2,
    rolename IN VARCHAR2
)
AS
BEGIN
    EXECUTE IMMEDIATE 'GRANT ' || rolename || ' TO ' || username;
END;
/

CREATE OR REPLACE PROCEDURE Sp_RevokePrivilegeOnTable(username VARCHAR2, tablename VARCHAR2) AS
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ALL PRIVILEGES ON ' || tablename || ' FROM ' || username;
END;
/


--Select All Role--
CREATE OR REPLACE PROCEDURE GET_ALL_ROLES AS
    V_EMP SYS_REFCURSOR;
BEGIN
    OPEN V_EMP FOR 
    SELECT ROLE FROM DBA_ROLES;
    DBMS_SQL.RETURN_RESULT(V_EMP);
END;
/
--Select All User--

CREATE OR REPLACE PROCEDURE GET_ALL_USERS AS
    V_EMP SYS_REFCURSOR;
BEGIN
    OPEN V_EMP FOR 
    SELECT USERNAME, ACCOUNT_STATUS
    FROM SYS.DBA_USERS;
    DBMS_SQL.RETURN_RESULT(V_EMP);
END;
/


--Revoke Privileges--

CREATE OR REPLACE PROCEDURE REVOKE_PRIVILEGES(USER_NAME VARCHAR2, QUYEN VARCHAR2) AS
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ' || QUYEN || ' FROM ' || USER_NAME;
END;
/


--Revoke With Admin Option --
CREATE OR REPLACE PROCEDURE REVOKE_ADMIN_OPTION(USER_NAME VARCHAR2, QUYEN VARCHAR2) AS
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ' || QUYEN || ' FROM ' || USER_NAME;
    EXECUTE IMMEDIATE 'GRANT ' || QUYEN || ' TO ' || USER_NAME;
END;
/

--See privileges --

CREATE OR REPLACE PROCEDURE CHECK_PRIVIS_A_ACTOR(USER_NAME VARCHAR2) AS
    V_EMP SYS_REFCURSOR;
BEGIN
    
    OPEN V_EMP FOR 
    SELECT PRIVILEGE,ADMIN_OPTION FROM DBA_SYS_PRIVS WHERE GRANTEE = USER_NAME;
    DBMS_SQL.RETURN_RESULT(V_EMP);
END;
/


CREATE OR REPLACE PROCEDURE GET_ALL_PRIVS AS
V_EMP SYS_REFCURSOR;
BEGIN
    OPEN V_EMP FOR 
    SELECT
  DISTINCT PRIVILEGE
    FROM
  DBA_SYS_PRIVS;
    DBMS_SQL.RETURN_RESULT(V_EMP);
END;
/


CREATE OR REPLACE PROCEDURE CREATE_USER(
	pi_username IN VARCHAR2,
	pi_password IN VARCHAR2
) IS
	user_name VARCHAR2(20) := pi_username;
	pwd VARCHAR2(20) := pi_password;
   	li_count INTEGER := 0;
   	lv_stmt VARCHAR2(1000);
BEGIN
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE(lv_stmt);
   	SELECT COUNT (1)
     	INTO li_count
     	FROM dba_users
   	WHERE username = UPPER(user_name);

   	IF li_count != 0
   	THEN
		lv_stmt := 'DROP USER '|| user_name || ' CASCADE';      	
		EXECUTE IMMEDIATE (lv_stmt);
   	END IF;
        lv_stmt := 'CREATE USER ' || user_name || ' IDENTIFIED BY ' || pwd || ' DEFAULT TABLESPACE SYSTEM';
	DBMS_OUTPUT.put_line(lv_stmt);

	EXECUTE IMMEDIATE (lv_stmt); 
                                                
        -- ****** Object: Roles for user ******
	lv_stmt := 'GRANT RESOURCE, CONNECT TO ' || user_name;
	EXECUTE IMMEDIATE (lv_stmt);
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
    EXECUTE IMMEDIATE(lv_stmt);
        
	COMMIT;
END CREATE_USER;
/

CREATE OR REPLACE PROCEDURE DROP_USER(
    pi_username VARCHAR2
)
AS
	user_name VARCHAR2(20);
   	li_count INTEGER;
   	lv_stmt VARCHAR2(1000);
BEGIN
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE(lv_stmt);
    user_name := pi_username;
    li_count := 0;
   	SELECT COUNT (1)
     	INTO li_count
     	FROM dba_users
        WHERE username = user_name;

   	IF li_count != 0
   	THEN
		lv_stmt := 'DROP USER '|| user_name || ' CASCADE';      	
		EXECUTE IMMEDIATE ( lv_stmt );
    ELSE
        lv_stmt := 'No User Found'; 
        DBMS_OUTPUT.put_line(lv_stmt);
   	END IF;
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
    EXECUTE IMMEDIATE(lv_stmt);
    COMMIT;
END DROP_USER;
/

--Grant Privilige with admin option--
create or replace PROCEDURE GRANT_ADMIN_OPTION(USER_NAME VARCHAR2, QUYEN VARCHAR2) AS
BEGIN
    EXECUTE IMMEDIATE 'GRANT ' || QUYEN || ' TO ' || USER_NAME || ' WITH ADMIN OPTION';
END;
/

--Grant Privilige--
create or replace PROCEDURE GRANT_PRIVILEGES(USER_NAME VARCHAR2, QUYEN VARCHAR2) AS
BEGIN
    EXECUTE IMMEDIATE 'GRANT ' || QUYEN || ' TO ' || USER_NAME;
END;
/

--Drop Role PROCEDURE
CREATE OR REPLACE PROCEDURE DROP_ROLE(
    pi_username VARCHAR2
)
AS
	user_name VARCHAR2(20);
   	li_count INTEGER;
   	lv_stmt VARCHAR2(1000);
BEGIN
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE(lv_stmt);
    user_name := pi_username;
    li_count := 0;
   	SELECT COUNT (1)
     	INTO li_count
     	FROM dba_roles
        WHERE role = user_name;

   	IF li_count != 0
   	THEN
		lv_stmt := 'DROP ROLE '|| user_name;      	
		EXECUTE IMMEDIATE ( lv_stmt );
    ELSE
        lv_stmt := 'No Role Found'; 
        DBMS_OUTPUT.put_line(lv_stmt);
   	END IF;
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
    EXECUTE IMMEDIATE(lv_stmt);
    COMMIT;
END DROP_ROLE;
/

--Create Role Procedure 
CREATE OR REPLACE PROCEDURE CREATE_ROLE(
	pi_username IN VARCHAR2,
    pi_password IN VARCHAR2
) IS
	user_name VARCHAR2(20) := pi_username;
   	li_count INTEGER := 0;
   	lv_stmt VARCHAR2(1000);
BEGIN
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
    EXECUTE IMMEDIATE(lv_stmt);
   	SELECT COUNT (1)
     	INTO li_count
     	FROM dba_roles
   	WHERE role = UPPER(user_name);

   	IF li_count != 0
   	THEN
		lv_stmt := 'DROP ROLE '|| user_name;      	
		EXECUTE IMMEDIATE (lv_stmt);
   	END IF;
        IF pi_password IS NULL THEN
            lv_stmt := 'CREATE ROLE ' || user_name;
            DBMS_OUTPUT.put_line(lv_stmt);
        ELSE 
            lv_stmt := 'CREATE ROLE ' || user_name || ' IDENTIFIED BY ' || pi_password;
            DBMS_OUTPUT.put_line(lv_stmt);
        END IF;
	EXECUTE IMMEDIATE (lv_stmt); 
                                                
        -- ****** Object: Roles for user ******
	lv_stmt := 'GRANT CREATE SESSION TO ' || user_name;
	EXECUTE IMMEDIATE (lv_stmt);
    lv_stmt := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
    EXECUTE IMMEDIATE(lv_stmt);
        
	COMMIT;
END CREATE_ROLE;
/

--CHANGE A USER PASSWORD
CREATE OR REPLACE PROCEDURE ChangeUserPassword(
    username IN VARCHAR2,
    new_password IN VARCHAR2
) AS
BEGIN
    IF new_password IS NOT NULL THEN 
        EXECUTE IMMEDIATE 'ALTER USER ' || username || ' IDENTIFIED BY ' || new_password;
    END IF;
END;
/


--CHANGE A ROLE PASSWORD
CREATE OR REPLACE PROCEDURE ChangeRolePassword(
    username IN VARCHAR2,
    new_password IN VARCHAR2
) AS
BEGIN
    IF new_password IS NOT NULL THEN
        EXECUTE IMMEDIATE 'ALTER ROLE ' || username || ' IDENTIFIED BY ' || new_password;
    END IF;
END;
/



