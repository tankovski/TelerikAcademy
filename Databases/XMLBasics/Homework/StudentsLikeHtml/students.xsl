<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <html>
      <body>
        <h2>ListOfStudents</h2>
        <ul>
          <xsl:for-each select="students/student">
            <li>
              <ul>
                <li>
                  <xsl:value-of select="name"/>
                </li>
                <li>
                  <xsl:value-of select="sex"/>
                </li>
                <li>
                  <xsl:value-of select="birthDate"/>
                </li>
                <li>
                  <xsl:value-of select="phone"/>
                </li>
                <li>
                  <xsl:value-of select="email"/>
                </li>
                <li>
                  <xsl:value-of select="course"/>
                </li>
                <li>
                  <xsl:value-of select="specialty"/>
                </li>
                <li>
                  <xsl:value-of select="facultyNumber"/>
                </li>
                <li>TakenExams
                  <xsl:for-each select="takenExams/exam">
                    <ul>
                      <li>
                        <xsl:value-of select="name"/>
                      </li>
                      <li>
                        <xsl:value-of select="tutor"/>
                      </li>
                      <li>
                        <xsl:value-of select="score"/>
                      </li>
                    </ul>
                  </xsl:for-each>
                </li>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
